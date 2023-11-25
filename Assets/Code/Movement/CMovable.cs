using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Movement
{
    [Serializable]
    public struct CMovable
    {
        public float rotation;
        public float movement;
        public float dampingMovement;
        public float dampingRotation;
    }
}