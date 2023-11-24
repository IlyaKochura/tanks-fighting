using Code.MonstersLogic.Components;
using Code.Movement;
using Leopotam.EcsLite;

namespace Code.MonstersLogic
{
    public class MonsterSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _monsterFilter;
        private EcsPool<CNavMeshAgentContainer> _navMeshPool;
        private EcsFilter _playerFilter;
        private EcsPool<CTransform> _transformPool;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            _monsterFilter = world.Filter<CMonster>().Inc<CNavMeshAgentContainer>().End();
            _playerFilter = world.Filter<CPlayerControlled>().Inc<CTransform>().End();
            _navMeshPool = world.GetPool<CNavMeshAgentContainer>();
            _transformPool = world.GetPool<CTransform>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var playerEntity in _playerFilter)
            {
                ref var playerTransform = ref _transformPool.Get(playerEntity);
                
                foreach (var entityMonsterEntity in _monsterFilter)
                {
                    ref var navMesh = ref _navMeshPool.Get(entityMonsterEntity);

                    navMesh.navMeshAgent.destination = playerTransform.transform.position;
                }
            }
        }
    }
}