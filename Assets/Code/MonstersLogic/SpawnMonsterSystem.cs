using System.Linq;
using AB_Utility.FromSceneToEntityConverter;
using Code.Configs;
using Code.MonstersLogic.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.MonstersLogic
{
    public class SpawnMonsterSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly MainConfig _mainConfig;
        private EcsFilter _spawnerFilter;
        private EcsPool<CMonsterSpawner> _spawnerPool;
        private EcsWorld _world;
        private int _counterSpawnedMonster;
        private EcsPool<CSpawnedMonsterCounter> _counterPool;

        public SpawnMonsterSystem(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();

            _spawnerFilter = _world.Filter<CMonsterSpawner>().End();
            _spawnerPool = _world.GetPool<CMonsterSpawner>();

            _counterPool = _world.GetPool<CSpawnedMonsterCounter>();
            _counterSpawnedMonster = _world.NewEntity();
            
            _counterPool.Add(_counterSpawnedMonster);
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _spawnerFilter)
            {
                var random = Random.Range(0, 2);

                ref var counter = ref _counterPool.Get(_counterSpawnedMonster);
                
                if (counter.spawnedMonsterCount >= _mainConfig.MaxMonsterSpawned)
                {
                    continue;
                }
                
                var anyMonster = _mainConfig.Monsters.First(x => random == x.chanceSpawn);

                var spawnTransform = _spawnerPool.Get(entity);

                EcsConverter.InstantiateAndCreateEntity(anyMonster.monsterPrefab, spawnTransform.transform.position, Quaternion.identity, _world);

                counter.spawnedMonsterCount++;
            }
        }
    }
}