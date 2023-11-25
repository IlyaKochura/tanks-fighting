using Code.DamageAndHealth.Components;
using LeoEcsPhysics;
using Leopotam.EcsLite;

namespace Code.DamageAndHealth.Systems
{
    public class DamageSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _damagedFilter;
        private EcsPool<CHealth> _healthPool;
        private EcsPool<CArmor> _armorPool;
        private EcsPool<DamageEvent> _damagePool;
        private EcsPool<DeathEvent> _deathPool;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            _damagedFilter = world.Filter<DamageEvent>().Inc<CHealth>().End();
            _armorPool = world.GetPool<CArmor>();
            _healthPool = world.GetPool<CHealth>();
            _damagePool = world.GetPool<DamageEvent>();
            _deathPool = world.GetPool<DeathEvent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _damagedFilter)
            {
                var damage = _damagePool.Get(entity);
                var armor = _armorPool.Get(entity);
                ref var health = ref _healthPool.Get(entity);

                health.health -= damage.applyDamage * armor.armor;

                if (health.health <= 0)
                {
                    _deathPool.Add(entity);
                }
            }
        }
    }
}