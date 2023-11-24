using System;
using Code.Shooting.Contracts;
using UnityEngine;

namespace Code.Shooting.Components
{
    [Serializable]
    public struct CShooter
    {
        public IWeapon CurrentWeapon;
        public Transform StartShootPos;
    }
}