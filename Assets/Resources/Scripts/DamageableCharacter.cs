using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableCharcter : MonoBehaviour,IDamageable
{
    Rigidbody2D rb;
    Collider2D physicsCollider;

    public int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if(health<=0)
            {
                gameObject.BroadcastMessage("OnDie");
            }
            else
            {
                gameObject.BroadcastMessage("OnDamage");
            }
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        Health -= damage;
        rb.AddForce(knockback);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = GetComponent<Collider2D>();
    }

}
