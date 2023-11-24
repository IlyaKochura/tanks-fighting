using Code.Shooting.Contracts;
using ObjectPool.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class TankCannon : IWeapon
    {
        private readonly Projectile _projectile;
        private readonly IObjectPool _objectPool;
        public TankCannon(Projectile projectile, IObjectPool objectPool /*, MainConfig*/)
        {
            _projectile = projectile;
            _objectPool = objectPool;
        }
        
        public void Shoot(Transform shootPos)
        {
            var spawnedObj = _objectPool.Spawn<Projectile>(_projectile.gameObject, shootPos.position, shootPos.rotation);
            spawnedObj.gameObject.tag = $"{nameof(TankCannon)}";
            Debug.LogError("TankCannonShoot");
        }
    }
}