using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    public float moveSpeed;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if(moveInput==Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
            if(moveInput.x>0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("isFacingRight", true);
            }
            if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("isFacingRight", false);
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveInput * moveSpeed); 
    }


    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }
}
