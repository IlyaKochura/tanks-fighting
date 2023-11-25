using Code.Configs;
using Code.DamageAndHealth.Contracts;
using Code.Shooting.Contracts;
using Code.Shooting.Enums;
using ObjectPool.Contracts;
using UnityEngine;

namespace Code.Shooting
{
    public class LazerGun : IWeapon
    {
        private readonly MainConfig _mainConfig;
        private readonly IObjectPool _objectPool;
        public WeaponsViewVariants WeaponsViewVariant => WeaponsViewVariants.LazerGun;

        public LazerGun(MainConfig mainConfig, IObjectPool objectPool)
        {
            _mainConfig = mainConfig;
            _objectPool = objectPool;
        }

        public void Shoot(Transform startPosition, Transform shootPosition)
        {
            var positionShoot = shootPosition.position;
            var shootDir = (positionShoot - startPosition.position).normalized;

            var ray = new Ray(positionShoot, shootDir);

            Physics.Raycast(ray, out var hit);

            var lazerEffect = _objectPool.Spawn<Lazer>(_mainConfig.LazerGunEffect.gameObject, positionShoot,
                Quaternion.identity);
            
            var hitCollider = hit.collider;

            Vector3 endPoint;
            
            if (hitCollider == null)
            {
                endPoint = ray.GetPoint(100f);
            }
            else
            {
                endPoint = hit.point;
                
                if(hitCollider.TryGetComponent(out IDamageable damageable))
                {
                    damageable.ApplyDamage(_mainConfig.LazerGunDamage);
                }
            }

            lazerEffect.SetupPoint(0, shootPosition.position);
            lazerEffect.SetupPoint(1, endPoint);
        }
    }
}