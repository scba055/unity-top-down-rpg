using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();  
    }

    private void FixedUpdate() 
    {
        // if movement input is not 0, try to move
        if (movementInput != Vector2.zero) {
            bool success = TryMove(movementInput);

            if (!success) {
                success = TryMove(new Vector2(movementInput.x , 0));

                if (!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }

            animator.SetBool("isMoving", success);
        } else {
            animator.SetBool("isMoving", false);

        }

        // set direction of sprite to movement direction
        
    }

    private bool TryMove(Vector2 direction) {
        // checks for potential collisions
        int count = rb.Cast(
                    direction, // direction - x and y between -1 and 1 that represent the direction from the body to look for collisions
                    movementFilter, // the setting that determine where a collision can occur on such as layers to collide with
                    castCollisions, // list of collisions to store the found collisions into after the cast is finished
                    moveSpeed * Time.fixedDeltaTime + collisionOffset // the amount to cast equal to the movement plus an offset
                );

                if (count == 0) {
                    rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                    return true;
                } else {
                    return false;
                }
    }

    void OnMove(InputValue movementValue) 
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
