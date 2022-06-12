using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // public enum AttackDirection {
    //     left, right
    // }

    // public AttackDirection attackDirection;
    Collider2D swordCollider;
    Vector2 rightAttackOffset;

    private void Start() {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position; // positions the hitbox to the current direction the player is facing
    }

    // private void Attack() { // allows the program to know which direction the attack is going
    //     switch(attackDirection) {
    //         case AttackDirection.left:
    //             AttackLeft();
    //         break;

    //         case AttackDirection.right:
    //             AttackRight();
    //         break;
    //     }
    // }

    public void AttackRight() {
        //print("Attack succeeded");
        swordCollider.enabled = true;
        transform.position = rightAttackOffset;
    }

    public void AttackLeft() {
        //print("Attack succeeded");
        swordCollider.enabled = true;
        transform.position = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            // deals damage to enemy
        }
    }
}
