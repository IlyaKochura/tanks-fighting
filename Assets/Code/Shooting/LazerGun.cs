using Code.Configs;
using Code.Shooting.Contracts;
using Code.Shooting.Enums;
using UnityEngine;

namespace Code.Shooting
{
    public class LazerGun : IWeapon
    {
        private readonly MainConfig _mainConfig;
        public WeaponsViewVariants WeaponsViewVariant => WeaponsViewVariants.LazerGun;

        public LazerGun(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }

        public void Shoot(Transform startPosition, Transform shootPosition)
        {
            var positionShoot = shootPosition.position;
            var shootDir = (positionShoot - startPosition.position).normalized;

            var ray = new Ray(positionShoot, shootDir);

            Physics.Raycast(ray, out var hit);
            
            var lazerEffect =
                Object.Instantiate(_mainConfig.LazerGunEffect, positionShoot, Quaternion.identity);
            
            var hitCollider = hit.collider;
            if (hitCollider.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_mainConfig.LazerGunDamage);
            }
            
            lazerEffect.SetPosition(0, shootPosition.position);
            lazerEffect.SetPosition(1, hit.point);

        }
    }
}