using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Movement
{
    [Serializable]
    public struct CMovable
    {
        // public Vector3 velocity;
        public float rotation;
        public float movement;
        public float dampingMovement;
        public float dampingRotation;
        public float maxSpeed;
    }
}