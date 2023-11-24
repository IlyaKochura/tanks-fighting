using System;
using UnityEngine.Serialization;

namespace Code.Movement
{
    [Serializable]
    public struct CMoveEngine
    {
        public float forceMovement;
        public float forceRotation;
    }
}