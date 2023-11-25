using System;
using Code.Shooting;
using UnityEngine;

namespace Code.Configs
{
    [Serializable][CreateAssetMenu(menuName = "Configs/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private int _lazerGunDamage;
        [SerializeField] private int _tankCannonDamage;
        [SerializeField] private LayerMask _monsterLayer;
        [SerializeField] private LineRenderer _lazerGunEffect;
        [SerializeField] private Projectile _projectilePrefab;

        public int LazerGunDamage => _lazerGunDamage;

        public int TankCannonDamage => _tankCannonDamage;

        public LayerMask MonsterLayer => _monsterLayer;

        public LineRenderer LazerGunEffect => _lazerGunEffect;

        public Projectile ProjectilePrefab => _projectilePrefab;
    }
}