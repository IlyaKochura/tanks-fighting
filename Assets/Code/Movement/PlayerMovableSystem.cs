using GameLib.LeoEcsLite.Wrapper.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.Movement
{
    public class PlayerMovableSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsPool<CMovable> _movablePool;
        private EcsPool<CTransform> _transformPool;
        private EcsFilter _playerFilter;
        private EcsPool<CConvertedGameObject> _gameobjectPool;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            _filter = world.Filter<CMovable>().Inc<CTransform>().Inc<CPlayerControlled>().End();
            _movablePool = world.GetPool<CMovable>();
            _transformPool = world.GetPool<CTransform>();
            _gameobjectPool = world.GetPool<CConvertedGameObject>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                if (!_gameobjectPool.Get(entity).GameObject)
                {
                    continue;
                }
                
                ref var transform = ref _transformPool.Get(entity);
                ref var movable = ref _movablePool.Get(entity);

                transform.transform.Translate(Vector3.forward * movable.movement);
                transform.transform.Rotate(Vector3.up * movable.rotation);

                movable.movement *= movable.dampingMovement;
                movable.rotation *= movable.dampingRotation;
            }
        }
    }
}