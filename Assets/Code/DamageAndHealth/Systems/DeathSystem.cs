using Code.DamageAndHealth.Components;
using GameLib.LeoEcsLite.Wrapper.Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Code.DamageAndHealth.Systems
{
    public class DeathSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsPool<CConvertedGameObject> _gameObjectPool;
        private EcsFilter _deathFilter;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            _deathFilter = world.Filter<DeathEvent>().End();
            _gameObjectPool = world.GetPool<CConvertedGameObject>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _deathFilter)
            {
                var gameObject = _gameObjectPool.Get(entity);

                Object.Destroy(gameObject.GameObject);
                
            }
        }
    }
}