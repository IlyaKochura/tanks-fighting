using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.LogError("player");
        }
        
        if (collision.collider.CompareTag("MachineGun"))
        {
            Debug.LogError("Gun");
        }
        
        if (collision.collider.CompareTag("TankCannon"))
        {
            Debug.LogError("Cannon");
        }
    }
}
