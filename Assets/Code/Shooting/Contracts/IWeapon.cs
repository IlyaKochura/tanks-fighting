using UnityEngine;

namespace Code.Shooting.Contracts
{
    public interface IWeapon
    {
        void Shoot(Transform shootPos);
    }
}