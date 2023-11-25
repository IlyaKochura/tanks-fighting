using Code.Configs;
using Code.Shooting.Contracts;
using Code.Shooting.Enums;
using ObjectPool.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class TankCannon : IWeapon
    {
        private readonly MainConfig _mainConfig;
        private readonly IObjectPool _objectPool;
        public WeaponsViewVariants WeaponsViewVariant => WeaponsViewVariants.TankCannon;
        public TankCannon(MainConfig mainConfig, IObjectPool objectPool)
        {
            _mainConfig = mainConfig;
            _objectPool = objectPool;
        }
        
        public void Shoot(Transform startPosition, Transform shootPosition)
        {
            var positionShoot = shootPosition.position;
            var spawnedObj = _objectPool.Spawn<Projectile>(_mainConfig.ProjectilePrefab.gameObject, positionShoot, shootPosition.localRotation);
            spawnedObj.tag = $"{nameof(TankCannon)}";
            
            spawnedObj.SetupDamage(_mainConfig.TankCannonDamage);

            var shootDir = (positionShoot - startPosition.position).normalized;

            spawnedObj.Shoot(shootDir);
        }
    }
}