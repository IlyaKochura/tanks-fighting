using Code.Shooting.Enums;
using UnityEngine;

namespace Code.Shooting.Contracts
{
    public interface IWeapon
    {
        public WeaponsViewVariants WeaponsViewVariant { get; }
        void Shoot(Transform shootPos, Transform cannonEnd);
    }
}