using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySlime : MonoBehaviour
{

    Animator animate;

    public float Health = 10;

    private void Start() {
        animate = GetComponent<Animator>();
    }

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
        animate.SetTrigger("Defeated");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
