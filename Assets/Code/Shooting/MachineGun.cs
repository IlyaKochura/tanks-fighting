using Code.Shooting.Contracts;
using ObjectPool.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class MachineGun : IWeapon
    {
        private readonly Projectile _projectile;
        private readonly IObjectPool _objectPool;

        public MachineGun(Projectile projectile, IObjectPool objectPool /*, MainConfig*/)
        {
            _projectile = projectile;
            _objectPool = objectPool;
        }
        
        public void Shoot(Transform shootPos)
        {
            for (int i = 0; i < 3; i++)
            {
                var spawnedObj = _objectPool.Spawn<Projectile>(_projectile.gameObject, shootPos.position, shootPos.rotation);
                spawnedObj.gameObject.tag = $"{nameof(MachineGun)}";
            }
        }
    }
}