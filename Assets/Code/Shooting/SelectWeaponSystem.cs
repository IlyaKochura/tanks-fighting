using System.Collections.Generic;
using Code.Configs;
using Code.Input;
using Code.Movement;
using Code.Shooting.Components;
using Code.Shooting.Contracts;
using Leopotam.EcsLite;
using ObjectPool.Contracts;

namespace Code.Shooting
{
    public class SelectWeaponSystem : IEcsInitSystem
    {
        private const int StartWeaponIndex = 0;
        
        private readonly IObjectPool _objectPool;
        private readonly MovableInputProvider _movableInputProvider;
        private readonly MainConfig _mainConfig;
        private EcsFilter _shooterFilter;
        private EcsPool<CShooter> _shooterPool;

        private List<IWeapon> _weapons = new();
        private int _currentWeaponIndex;

        public SelectWeaponSystem(IObjectPool objectPool,
            MovableInputProvider movableInputProvider, MainConfig mainConfig)
        {
            _objectPool = objectPool;
            _movableInputProvider = movableInputProvider;
            _mainConfig = mainConfig;
        }

        public void Init(IEcsSystems systems)
        {
            var world = systems.GetWorld();

            _shooterFilter = world.Filter<CShooter>().Inc<CPlayerControlled>().End();
            _shooterPool = world.GetPool<CShooter>();

            _weapons.Add(new LazerGun(_mainConfig, _objectPool));
            _weapons.Add(new TankCannon(_mainConfig, _objectPool));

            _currentWeaponIndex = StartWeaponIndex;

            Select();

            _movableInputProvider.LeftWeaponSelect += DecrementIndex;
            _movableInputProvider.RightWeaponSelect += IncrementIndex;
        }

        private void DecrementIndex()
        {
            if (_currentWeaponIndex <= 0)
            {
                return;
            }

            _currentWeaponIndex--;
            Select();
        }

        private void IncrementIndex()
        {
            if (_currentWeaponIndex >= _weapons.Count - 1)
            {
                return;
            }

            _currentWeaponIndex++;
            Select();
        }

        private void Select()
        {
            foreach (var entity in _shooterFilter)
            {
                ref var shooter = ref _shooterPool.Get(entity);

                shooter.currentWeapon = _weapons[_currentWeaponIndex];
                
                shooter.weaponsViewsContainer.DisableAll();

                shooter.weaponsViewsContainer.EnableWeaponView(shooter.currentWeapon.WeaponsViewVariant);
            }
        }
    }
}