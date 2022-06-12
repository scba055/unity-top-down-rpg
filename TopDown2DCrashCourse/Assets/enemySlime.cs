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
        } else {
            takingDamage();
        }
        print(getHealth());
    }

    public void takingDamage() {
        animate.SetBool("isTakingDamage", true);
        animate.SetTrigger("isDamaged");
    }

    public void noDamage() {
        animate.SetBool("isTakingDamage", false);
    }

    public void Defeated() {
        animate.SetTrigger("Defeated");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
