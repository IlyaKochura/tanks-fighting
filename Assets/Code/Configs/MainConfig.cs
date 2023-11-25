using System;
using System.Collections.Generic;
using Code.MonstersLogic.Model;
using Code.Shooting;
using UnityEngine;

namespace Code.Configs
{
    [Serializable][CreateAssetMenu(menuName = "Configs/MainConfig")]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private int _lazerGunDamage;
        [SerializeField] private int _tankCannonDamage;
        [SerializeField] private Lazer _lazerGunEffect;
        [SerializeField] private Projectile _projectilePrefab;
        [Header("Monsters")] 
        [SerializeField] private List<SpawnMonsterModel> _monsters;
        [SerializeField] private int _maxMonsterSpawned;
        
        public int LazerGunDamage => _lazerGunDamage;
        public int TankCannonDamage => _tankCannonDamage;
        public List<SpawnMonsterModel>  Monsters => _monsters;
        public int MaxMonsterSpawned => _maxMonsterSpawned;
        public Lazer LazerGunEffect => _lazerGunEffect;
        public Projectile ProjectilePrefab => _projectilePrefab;
    }
}