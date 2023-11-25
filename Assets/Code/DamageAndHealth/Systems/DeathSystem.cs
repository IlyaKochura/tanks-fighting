using Code.DamageAndHealth.Components;
using GameLib.LeoEcsLite.Wrapper.Components;
using Leopotam.EcsLite;
using ObjectPool.Runtime.Contracts;

namespace Code.DamageAndHealth.Systems
{
    public class DeathSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsPool<CConvertedGameObject> _gameobjectPoll;
        private EcsFilter _deathFilter;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            _deathFilter = world.Filter<DeathEvent>().End();
            _gameobjectPoll = world.GetPool<CConvertedGameObject>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _deathFilter)
            {
                var gameobject = _gameobjectPoll.Get(entity);

                if (gameobject.GameObject.TryGetComponent(out IRecycle recycle))
                {
                    recycle.Recycle();
                    continue;
                }
                
                gameobject.GameObject.SetActive(false);
            }
        }
    }
}