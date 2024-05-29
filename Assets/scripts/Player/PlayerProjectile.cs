using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damageAmount = 1; // The amount of damage the projectile deals to enemies

    private Rigidbody2D rb; // The rigidbody component of the projectile
    private float lifespan = 5f; // The lifespan of the projectile in seconds

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifespan);
    }

   /* void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(damageAmount);
            }
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Tile"))
        {
            Destroy(gameObject);
        }
    }
}
