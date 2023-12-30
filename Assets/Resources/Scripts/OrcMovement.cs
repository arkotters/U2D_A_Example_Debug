using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    DetectionZone detectionZone;
    Animator animator;


    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        detectionZone = GetComponent<DetectionZone>();
        animator = GetComponent<Animator>();  
    }
    private void FixedUpdate()
    {
        if(detectionZone.detectedObjs != null)
        {
            Vector2 direction = (detectionZone.detectedObjs.transform.position - transform.position);
            if (direction.magnitude <= detectionZone.viewRadius)
            {
                rb.AddForce(direction.normalized * speed);
                if( direction.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                if(direction.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                OnWalk();
            }
            else
            {
                OnWalkStop();
            }
        }
        
    }


    public void OnWalk()
    {
        animator.SetBool("isWalking", true);
    }
    public void OnWalkStop()
    {
        animator.SetBool("isWalking", false);
    }

    void OnDamage()
    {
        animator.SetTrigger("isDamage");
    }

    void OnDie()
    {
        animator.SetTrigger("isDead");
    }
}
