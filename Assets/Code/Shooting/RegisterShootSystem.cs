using Code.Input;
using Code.Movement;
using Code.Shooting.Components;
using Leopotam.EcsLite;

namespace Code.Shooting
{
    public class RegisterShootSystem : IEcsInitSystem
    {
        private readonly MovableInputProvider _movableInputProvider;
        private EcsFilter _shootingFilter;
        private EcsPool<CShootOneFrame> _shooterPool;

        public RegisterShootSystem(MovableInputProvider movableInputProvider)
        {
            _movableInputProvider = movableInputProvider;
        }
        
        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            _shootingFilter = world.Filter<CShooter>().Inc<CPlayerControlled>().End();
            _shooterPool = world.GetPool<CShootOneFrame>();

            _movableInputProvider.FireEvent += Shoot;
        }

        private void Shoot()
        {
            foreach (var entity in _shootingFilter)
            {
                _shooterPool.Add(entity);
            }
        }
    }
}