using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 5f; // The speed at which the enemy moves
    public float detectionDistance = 10f; // The distance at which the enemy can detect the player
    public float stoppingDistance = 1f; // The distance at which the enemy stops following the player
    private bool chasing = false;

    private Transform player; // The transform of the player
    private Rigidbody2D rb; // The rigidbody of the enemy
    private EnemyHealth EnemyHealth;

    void Start()
    {
        // Find the player's transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        EnemyHealth = GetComponent<EnemyHealth>();
    }

    void FixedUpdate()
    {
        // Calculate the distance between the enemy and the player
        float distance = Vector2.Distance(transform.position, player.position);

        // Check if the player is within detection range

        if (distance <= detectionDistance)
        {
            chasing = true;
        }

        if (!chasing)
        {
            rb.velocity = Vector2.zero;
        }
        else if (EnemyHealth.hit == false)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        if (EnemyHealth.hit == false)
        {
            if (transform.position.x > player.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0); //movingRight = false;
            }
            if (transform.position.x < player.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0); //movingRight = true;
            }
        }

    }
}
