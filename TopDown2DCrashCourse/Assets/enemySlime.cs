using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySlime : MonoBehaviour
{
    public float Health {
        set {
            health = value;
            if (health <= 0) {
                Defeated();
            }
        }
    }
    
    public void TakeDamage(float damage) {
        health -= damage;
    }

    public void Defeated() {
        
    }
}
