using Code.Shooting.Contracts;
using Code.Shooting.Enums;
using ObjectPool.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class LazerGun : IWeapon
    {
        private readonly Projectile _projectile;
        private readonly IObjectPool _objectPool;
        public WeaponsViewVariants WeaponsViewVariant => WeaponsViewVariants.LazerGun;

        public LazerGun(Projectile projectile, IObjectPool objectPool /*, MainConfig*/)
        {
            _projectile = projectile;
            _objectPool = objectPool;
        }
        
        public void Shoot(Transform shootPos)
        {
            for (int i = 0; i < 3; i++)
            {
                var spawnedObj = _objectPool.Spawn<Projectile>(_projectile.gameObject, shootPos.position, shootPos.rotation);
                spawnedObj.gameObject.tag = $"{nameof(LazerGun)}";
            }
        }

        public void Shoot(Transform shootPos, Transform cannonEnd)
        {
            // Ray ray = new Ray(position, shootPos.forward);
            // if (Physics.Raycast(ray, out var hit))
            // {
            //     //hit.rigidbody.AddForceAtPosition(ray.direction * 10, hit.point, ForceMode.Impulse);
            //     Debug.DrawRay(position, );
            //     Debug.LogError(hit.collider.tag);
            // }
            //
            // Debug.LogError("TankCannonShoot");
        }
    }
}