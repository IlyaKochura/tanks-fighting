using Code.Shooting.Components;
using Leopotam.EcsLite;

namespace Code.Shooting
{
    public class ShootSystem : IEcsInitSystem, IEcsRunSystem
    {
        private EcsFilter _filterShooter;
        private EcsPool<CShooter> _shooterPool;

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            _filterShooter = world.Filter<CShooter>().Inc<CShootOneFrame>().End();
            _shooterPool = world.GetPool<CShooter>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filterShooter)
            {
                ref var shooter = ref _shooterPool.Get(entity);
                shooter.currentWeapon.Shoot(shooter.startPosition, shooter.shootPosition);
            }
        }
    }
}