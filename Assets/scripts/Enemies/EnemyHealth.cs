using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyHealth : MonoBehaviour
{

    public bool damageable = true;
    public bool Static;
    public bool damaging;
    public bool brekable;
    public bool isBoss;
    public bool secret;
    public bool brekableCollective;

    public bool OnTouchBrake;
    private float BrakingTime = 1f;
    private float BrakeTime = 0.5f;
    private SpriteRenderer spriteRenderer;
    public Sprite spriteBraking;
    public Sprite spriteeBrake;
    public Sprite spriteUnbraked;
    
    public BossKillCounter bossKillCounter;
    public CollectiblesList collectiblesList;
    public int collectibleNumber;

    [SerializeField] private GameObject SecretFOW;

    public int startingHealth = 3;
    public int currentHealth;
    [SerializeField] private float invulnerabilityTime = .2f;
    public float respawnTime = 5;
    public bool hit;

    //public bool dead;

    //Allows the player to be forced up when performing a downward strike above the enemy
    //public bool giveUpwardForce = true;

    private GameObject player;
    [SerializeField] private EnemyMovement EnemyMovement;
    private PlayerAttack playerAttack;
    private Rigidbody2D enemyRB;

    public BrekableObject Holder;

    public SimpleFlash simpleFlash;
    [SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        //Sets the enemy to the max amount of health when the scene loads
        currentHealth = startingHealth;
        /*if (dead)
        {
            gameObject.SetActive(false);
        }*/
        if (isBoss && PlayerPrefs.GetInt(collectibleNumber.ToString()) == collectibleNumber)
        {
            StartCoroutine(Death());
        }
        if (brekableCollective && PlayerPrefs.GetInt(collectibleNumber.ToString()) == collectibleNumber)
        {
            Brake();
        }
        simpleFlash = GetComponent<SimpleFlash>();
        enemyRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    public void Damage(int amount)
    {
        //First checks to see if the player is currently in an invulnerable state; if not it runs the following logic.
        if (damageable == true && !hit && currentHealth > 0)
        {
            if (simpleFlash != null)
            {
                simpleFlash.Flash();
            }

            //skeletorAnimator.SetTrigger("Skeletor_Hit");

            //First sets hit to true
            hit = true;
            //Reduces currentHealthPoints by the amount value that was set by whatever script called this method, for this tutorial in the OnTriggerEnter2D() method
            currentHealth -= amount;

            if (player.transform.position.x <= transform.position.x && !Static && !isBoss)
            {
                //player on left
                if (player.transform.position.y + 1f >= transform.position.y && player.transform.position.y + -1f <= transform.position.y)
                {
                    enemyRB.velocity = new Vector2(playerAttack.PlayerAttackKB, enemyRB.velocity.y);
                    //Debug.Log("player on left");
                }
                //Player on left below
                else if (player.transform.position.y + 1f <= transform.position.y)
                {
                    enemyRB.velocity = new Vector2(playerAttack.PlayerAttackKB, playerAttack.PlayerAttackKB);
                    //Debug.Log("Player on left below");
                }
                //Player on left abowe
                else if (player.transform.position.y + -1f >= transform.position.y)
                {
                    enemyRB.velocity = new Vector2(playerAttack.PlayerAttackKB, -playerAttack.PlayerAttackKB);
                    //Debug.Log("Player on left abowe");
                }
            }

            if (player.transform.position.x > transform.position.x && !Static && !isBoss)
            {
                //player on right
                if (player.transform.position.y + 1f >= transform.position.y && player.transform.position.y + -1f <= transform.position.y)
                {
                    enemyRB.velocity = new Vector2(-playerAttack.PlayerAttackKB, enemyRB.velocity.y);
                    //Debug.Log("player on right");
                }
                //Player on right below
                else if (player.transform.position.y + 1f <= transform.position.y)
                {
                    enemyRB.velocity = new Vector2(-playerAttack.PlayerAttackKB, enemyRB.velocity.y);
                    //Debug.Log("Player on right below");
                }
                //Player on right abowe
                else if (player.transform.position.y + -1f >= transform.position.y)
                {
                    enemyRB.velocity = new Vector2(-playerAttack.PlayerAttackKB, -enemyRB.velocity.y);
                    //Debug.Log("Player on right abowe");
                }

            }

            //If currentHealthPoints is below zero, player is dead, and then we handle all the logic to manage the dead state
            if (currentHealth <= 0)
            {
                //Caps currentHealth to 0 for cleaner code
                currentHealth = 0;
                //Removes GameObject from the scene; this should probably play a dying animation in a method that would handle all the other death logic, but for the test it just disables it from the scene
                StartCoroutine(Death());
            }
            else
            {
                //Coroutine that runs to allow the enemy to receive damage again
                StartCoroutine(TurnOffHit());

                if (brekable)
                {
                    Brake();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (OnTouchBrake)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Holder.respawnCounter = respawnTime;
                StartCoroutine(BrakingTimer());
            }
        }
    }
    //Coroutine that runs to allow the enemy to receive damage again
    private IEnumerator TurnOffHit()
    {
        //Wait in the amount of invulnerabilityTime, which by default is .2 seconds
        yield return new WaitForSeconds(invulnerabilityTime);
        //Turn off the hit bool so the enemy can receive damage again
        hit = false;
    }
    private IEnumerator BrakingTimer()
    {
        spriteRenderer.sprite = spriteBraking;
        yield return new WaitForSeconds(BrakingTime);
        spriteRenderer.sprite = spriteeBrake;
        yield return new WaitForSeconds(BrakeTime);
        deathSoundEffect.Play();
        spriteRenderer.sprite = spriteUnbraked;
        gameObject.SetActive(false);
    }
    private IEnumerator Death()
    {
        if (isBoss)
        {
            if (PlayerPrefs.GetInt(collectibleNumber.ToString()) != collectibleNumber)
            {
                deathSoundEffect.Play();
            }
            bossKillCounter.bossKill += 1;
            bossKillCounter.BossCheck();
        }
        else
        {
            deathSoundEffect.Play();
        }
        //dead = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
    private void Brake()
    {
        if (brekableCollective)
        {
            if (PlayerPrefs.GetInt(collectibleNumber.ToString()) != collectibleNumber)
            {
                deathSoundEffect.Play();
            }
            PlayerPrefs.SetInt(collectibleNumber.ToString(), collectibleNumber);
        }
        else
        {
            deathSoundEffect.Play();
        }

        Holder.respawnCounter = respawnTime;
        hit = false;
        if (secret)
        {
            SecretFOW.SetActive(false);
        }
        Holder.brekableObject.SetActive(false);
    }
}