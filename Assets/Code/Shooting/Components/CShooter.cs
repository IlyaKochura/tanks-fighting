using System;
using Code.Shooting.Contracts;
using UnityEngine;

namespace Code.Shooting.Components
{
    [Serializable]
    public struct CShooter
    {
        public IWeapon currentWeapon;
        public Transform startPosition;
        public Transform shootPosition;
        public WeaponsViewsContainer weaponsViewsContainer;
    }
}