using AB_Utility.FromSceneToEntityConverter;
using Code.Input;
using Code.Movement;
using LeoEcsPhysics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
#if UNITY_EDITOR
using Leopotam.EcsLite.UnityEditor;
#endif
using Zenject;

namespace Code.EcsInit
{
    public class EcsInstaller : MonoInstaller
    {
        [SerializeField] private MovableInputProvider _movableInputProvider;
        
        EcsWorld _world;
        IEcsSystems _systems;

        public override void InstallBindings()
        {
            _world = new EcsWorld ();
            Container.Bind<EcsWorld>().FromInstance(_world);
        }
        
        public override void Start()
        {
            EcsPhysicsEvents.ecsWorld = _world;
            _systems = new EcsSystems (_world);
            
            _world.ConvertSceneFromWorld();
            
            RegisterDebug();
            RegisterInput();
            RegisterMovement();

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
                .Add(new MovableSystem())
                .DelHere<CMoveInputEvent>();
        }

        private void RegisterDebug()
        {
#if UNITY_EDITOR
            _systems.Add(new EcsWorldDebugSystem())
                .Add(new EcsSystemsDebugSystem());
#endif
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