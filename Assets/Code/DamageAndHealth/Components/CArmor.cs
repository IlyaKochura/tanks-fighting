using System;
using UnityEngine;

namespace Code.DamageAndHealth.Components
{
    [Serializable]
    public struct CArmor
    {
        [Range(0,1)]public float armor;
    }
}