using AB_Utility.FromSceneToEntityConverter;
using Code.Configs;
using Code.DamageAndHealth.Systems;
using Code.Input;
using Code.MonstersLogic;
using Code.Movement;
using Code.Shooting;
using Code.Shooting.Components;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using ObjectPool.Contracts;
using ScreenManager.Runtime.Contracts;
using UnityEngine;
#if UNITY_EDITOR
using Leopotam.EcsLite.UnityEditor;
#endif
using Zenject;
using DestroyEntitySystem = Code.DamageAndHealth.Systems.DestroyEntitySystem;

namespace Code.EcsInit
{
    public class EcsInstaller : MonoInstaller
    {
        [SerializeField] private MovableInputProvider _movableInputProvider;
        [SerializeField] private MainConfig _mainConfig;

        EcsWorld _world;
        IEcsSystems _systems;
        private IObjectPool _objectPool;
        private IScreenManager _screenManager;

        public override void InstallBindings()
        {
            _world = new EcsWorld ();
            Container.Bind<EcsWorld>().FromInstance(_world);
        }
        
        public override void Start()
        {
            EcsPhysicsEvents.ecsWorld = _world;
            _systems = new EcsSystems (_world);
            
            _objectPool = Container.Resolve<IObjectPool>();
            _screenManager = Container.Resolve<IScreenManager>();
            
            _world.ConvertSceneFromWorld();
            
            RegisterDebug();
            RegisterInput();
            RegisterMovement();
            RegisterShootSystems();
            RegisterMonstersLogic();
            RegisterDamageSystems();

            _systems?.Init ();
        }

        public void Update()
        {
            _systems?.Run();
        }
        
        private void RegisterInput()
        {
            _systems.Add(new MoveInputSystem(_movableInputProvider));
        }

        private void RegisterMovement()
        {
            _systems.Add(new PlayerMovementSystem())
                .Add(new PlayerMovableSystem())
                .DelHere<CMoveInputEvent>();
        }

        private void RegisterDebug()
        {
#if UNITY_EDITOR
            _systems.Add(new EcsWorldDebugSystem())
                .Add(new EcsSystemsDebugSystem());
#endif
        }

        private void RegisterShootSystems()
        {
            _systems.Add(new SelectWeaponSystem(_objectPool, _movableInputProvider, _mainConfig))
                .Add(new RegisterShootSystem(_movableInputProvider))
                .Add(new ShootSystem())
                .DelHere<CShootOneFrame>();
        }

        private void RegisterMonstersLogic()
        {
            _systems.Add(new MonsterSystem())
                .Add(new SpawnMonsterSystem(_mainConfig));
        }

        private void RegisterDamageSystems()
        {
            _systems.Add(new DamageSystem())
                .DelHere<DamageEvent>()
                .Add(new DeathSystem())
                .Add(new DestroyEntitySystem(_screenManager));
        }

        void OnDestroy()
        {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
            }
            
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}