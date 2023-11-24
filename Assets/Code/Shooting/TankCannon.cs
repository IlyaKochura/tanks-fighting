using Code.Shooting.Contracts;
using Code.Shooting.Enums;
using ObjectPool.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class TankCannon : IWeapon
    {
        private readonly Projectile _projectile;
        private readonly IObjectPool _objectPool;
        public WeaponsViewVariants WeaponsViewVariant => WeaponsViewVariants.TankCannon;
        public TankCannon(Projectile projectile, IObjectPool objectPool)
        {
            _projectile = projectile;
            _objectPool = objectPool;
        }
        
        public void Shoot(Transform shootPos, Transform cannonEndPoint)
        {
            var positionStart = shootPos.position;
            
            var spawnedObj = _objectPool.Spawn<Projectile>(_projectile.gameObject, positionStart, shootPos.rotation);
            spawnedObj.tag = $"{nameof(TankCannon)}";
            
            var shootDir = (cannonEndPoint.position - positionStart).normalized;
            
            spawnedObj.Shoot(shootDir);
        }
    }
}