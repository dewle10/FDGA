using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public float distance;
    public float jumpForceMin;
    public float jumpForceMax;
    private float jumpForce;
    public float bigJumpForceX;
    public float bigJumpForceY;
    private bool bigJumping = false;

    private float lastTimeRandomed;
    private float lastTimeJumped;
    private float lastAnimedJumpTime;
    private float lastTimeBigJump;

    public float checkCD = 1;
    public float jumpCD = 10;
    public float bigJumpCD = 30;
    public float bigJumpAnimTime = 0.5f;
    private float jumpCheck;
    private float bigJumpCheck;
    private float hoverDistance = 3f;


    private Transform playerTransform;
    private Rigidbody2D bossRB;
    public EnemyHealth EnemyHealth;

    public GameObject enemyprojectilePrefab; // The projectile prefab to be shot
    public float fireRate = 1.5f; // The rate of fire in seconds
    public float animTime = 1f;
    //[SerializeField] private float lastFiredTime = 0f; // The time when the player last fired a projectile
    //[SerializeField] private float lastAnimedTime = 0f;
    [SerializeField] private Transform Firepoint;

    public Animator skeletorAnimator;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        bossRB = GetComponent<Rigidbody2D>();
        EnemyHealth = GetComponent<EnemyHealth>();
        StartCoroutine(Shoot());
        //lastFiredTime = 0f;
        //lastAnimedTime = 0f;
    }

    void Update()
    {
        //MOVING-----------------------------------------------------------------------------
        if (Vector2.Distance(transform.position, playerTransform.position) <= distance)
        {
            if (EnemyHealth.hit == false && !bigJumping)
            {
                if (transform.position.x < playerTransform.position.x)
                {
                    bossRB.velocity = new Vector2(-speed * 2, bossRB.velocity.y);
                    hoverDistance = Random.Range(1f, 10f);
                }
                if (transform.position.x > playerTransform.position.x)
                {
                    bossRB.velocity = new Vector2(speed * 2, bossRB.velocity.y);
                    hoverDistance = Random.Range(1f, 10f);
                }
            }
        }
        else if ((Vector2.Distance(transform.position, playerTransform.position) >= distance + hoverDistance))
        {
            if (EnemyHealth.hit == false && !bigJumping)
            {
                if (transform.position.x >= playerTransform.position.x)
                {
                    bossRB.velocity = new Vector2(-speed * 2, bossRB.velocity.y);
                }
                if (transform.position.x < playerTransform.position.x)
                {
                    bossRB.velocity = new Vector2(speed * 2, bossRB.velocity.y);
                }
            }
        }
        if (transform.position.x >= playerTransform.position.x)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //JUMPING-----------------------------------------------------------------------------

        if (Time.time > lastTimeRandomed + checkCD)
        {
            jumpCheck = Random.Range(0f, 10f);
            if(playerTransform.position.y > transform.position.y)
            {
                jumpCheck = jumpCheck * 1.5f;
            }
            jumpForce = Random.Range(jumpForceMin, jumpForceMax);
            lastTimeRandomed = Time.time;
        }
        if (jumpCheck > 9f && Time.time > lastTimeJumped + jumpCD)
        {
            bossRB.velocity = new Vector2(bossRB.velocity.x, jumpForce);
            jumpCheck = Random.Range(0f, 10f);
            lastTimeJumped = Time.time;
        }
        //SHOTING-----------------------------------------------------------------------------
        /*
        if (Time.time > lastAnimedTime + fireRate)
        {
            skeletorAnimator.SetTrigger("Skeletor_Attack");
            lastAnimedTime = Time.time;
        }
        if (Time.time > lastFiredTime + fireRate + animTime)
        {
            GameObject projectile = Instantiate(enemyprojectilePrefab, new Vector3(Firepoint.transform.position.x, Firepoint.transform.position.y, 0), Quaternion.identity);
            if (transform.position.x >= playerTransform.position.x)
            {
                projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            lastFiredTime = Time.time - animTime;
        }*/
        //BIG JUMP-----------------------------------------------------------------------------
        if (Time.time > lastAnimedJumpTime + bigJumpCD + bigJumpCheck)
        {
            skeletorAnimator.SetTrigger("Skeletor_Jump");
            lastAnimedJumpTime = Time.time;
        }
        if (Time.time > lastTimeBigJump + bigJumpCD + bigJumpCheck + bigJumpAnimTime)
        {
            lastTimeBigJump = Time.time - bigJumpAnimTime;
            bigJumping = true;
            bigJumpCheck = Random.Range(0f, 5f);

            if (transform.position.x >= playerTransform.position.x)
            {
                bossRB.velocity = new Vector2(-bigJumpForceX, bigJumpForceY);
            }
            else
            {
                bossRB.velocity = new Vector2(bigJumpForceX, bigJumpForceY);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Tile"))
        {
            bigJumping = false;
        }
    }

    IEnumerator Shoot()
    {
        skeletorAnimator.SetTrigger("Skeletor_Attack");
        yield return new WaitForSeconds(animTime);
        GameObject projectile = Instantiate(enemyprojectilePrefab, new Vector3(Firepoint.transform.position.x, Firepoint.transform.position.y, 0), Quaternion.identity);
        if (transform.position.x >= playerTransform.position.x)
        {
            projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        yield return new WaitForSeconds(fireRate);
        StartCoroutine(Shoot());
    }
}