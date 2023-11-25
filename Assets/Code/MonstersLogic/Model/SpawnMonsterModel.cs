using System;
using UnityEngine;

namespace Code.MonstersLogic.Model
{
    [Serializable]
    public class SpawnMonsterModel
    {
        public GameObject monsterPrefab;
        public int chanceSpawn;
    }
}