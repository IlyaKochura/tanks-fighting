using Code.DamageAndHealth.Components;
using Code.MonstersLogic.Components;
using Code.Movement;
using Code.UI.Screens;
using Leopotam.EcsLite;
using ScreenManager.Runtime.Contracts;

namespace Code.DamageAndHealth.Systems
{
    public class DestroyEntitySystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly IScreenManager _screenManager;
        private EcsFilter _counterFilter;
        private EcsFilter _deathFilter;
        private EcsPool<CSpawnedMonsterCounter> _counterPool;
        private EcsWorld _world;
        private EcsPool<CMonster> _monsterPool;
        private EcsPool<CPlayerControlled> _playerPool;

        public DestroyEntitySystem(IScreenManager screenManager)
        {
            _screenManager = screenManager;
        }
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _deathFilter = _world.Filter<DeathEvent>().End();
            _counterFilter = _world.Filter<CSpawnedMonsterCounter>().End();

            _counterPool = _world.GetPool<CSpawnedMonsterCounter>();
            _monsterPool = _world.GetPool<CMonster>();
            _playerPool = _world.GetPool<CPlayerControlled>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entityCounter in _counterFilter)
            {
                ref var counter = ref _counterPool.Get(entityCounter);
                foreach (var entityDeath in _deathFilter)
                {
                    if (_monsterPool.Has(entityDeath))
                    {
                        counter.spawnedMonsterCount--;
                    }

                    if (_playerPool.Has(entityDeath))
                    {
                        _screenManager.ShowScreen<DefeatScreen>();
                    }
                    _world.DelEntity(entityDeath);
                }
            }
        }
    }
}