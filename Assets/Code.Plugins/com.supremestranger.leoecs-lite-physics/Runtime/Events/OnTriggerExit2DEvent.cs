﻿using UnityEngine;

namespace LeoEcsPhysics
{
    public struct OnTriggerExit2DEvent
    {
        public int entityId;
        public GameObject senderGameObject;
        public Collider2D collider2D;
    }
}