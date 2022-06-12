using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySlime : MonoBehaviour
{
    public float Health = 10;

    public float getHealth() {
        return Health;
    }

    public void setHealth(float value) {
        Health -= value;
        if (Health <= 0) {
            Defeated();
        }
        print(getHealth());
    }

    public void Defeated() {
        Destroy(gameObject);
    }
}
