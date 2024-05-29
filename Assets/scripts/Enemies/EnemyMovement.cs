using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float Gdistance;
    public float Wdistance;
    private bool movingRight = true;

    public Transform groundDetection;
    [SerializeField] private LayerMask WallLayer;
    private Rigidbody2D Erb;

    public EnemyHealth EnemyHealth;

    private GameObject player;
    public bool ChasingEnemy;
    public float chaseDistance;


    private void Start()
    {
        Erb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < chaseDistance && ChasingEnemy == true)
        {
            if (EnemyHealth.hit == false)
            {
                if (transform.position.x >= player.transform.position.x + 1f)
                {
                    Erb.velocity = new Vector2(-speed * 2, Erb.velocity.y);
                    transform.eulerAngles = new Vector3(0, -180, 0); movingRight = false;
                }
                if (transform.position.x < player.transform.position.x)
                {
                    Erb.velocity = new Vector2(speed * 2, Erb.velocity.y);
                    transform.eulerAngles = new Vector3(0, 0, 0); movingRight = true;
                }
            }
        }
        else
        {
            if (EnemyHealth.hit == false)
            {
                if (movingRight == true)
                {
                    Erb.velocity = new Vector2(speed, Erb.velocity.y);
                }
                else
                {
                    Erb.velocity = new Vector2(-speed, Erb.velocity.y);
                }

            }
        }
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, Gdistance);
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.up, Wdistance, WallLayer);
        if (groundInfo.collider == false || wallInfo.collider == true)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0); movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0); movingRight = true;
            }
        }
    }
    /*void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }*/
}
