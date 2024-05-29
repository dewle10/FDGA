using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AttackCounter;
    public float AttackCooldown;

    private float attackTimeCounterR;
    private float attackTimeCounterL;
    private float attackTimeCounterD;
    private float attackTimeCounterU;
    public float attackTime = 1f;

    public LayerMask itisTile;
    public LayerMask itisEnemy;
    public LayerMask itisprojectile;
    public float attackRange;
    [SerializeField] private int damageAmount = 1;
    public float PlayerAttackKB;

    public Transform attackPosR;
    public Transform attackPosL;
    public Transform attackPosD;
    public Transform attackPosU;
    public float attackPosRL;

    public GameObject attackspriteR;
    public GameObject attackspriteL;
    public GameObject attackspriteU;
    public GameObject attackspriteD;

    public GameObject Player;
    public Transform PlayerPos;

    public bool RightTrigger = false;
    public bool LeftTrigger = false;
    public bool DownTrigger = false;
    public bool UpTrigger = false;

    public CharacterController2D CharacterController2D;
    public PlayerShoot PlayerShoot;
    public Animator playerAnimator;
    public Animator attackAnimatorR;
    public Animator attackAnimatorL;
    public Animator attackAnimatorD;
    public Animator attackAnimatorU;

    public PlayerInfo playerInfo;
    [SerializeField] private AudioSource attackASoundEffect;
    void Update()
    {

        if (AttackCounter <= attackTime)
        {
            attackspriteR.SetActive(false);
            attackspriteL.SetActive(false);
            attackspriteD.SetActive(false);
            attackspriteU.SetActive(false);

            RightTrigger = false;
            LeftTrigger = false;
            DownTrigger = false;
            UpTrigger = false;
        }

        //ATTACK RIGHT
        if (attackTimeCounterR > 0)
        {
            RightTrigger = true;
            attackspriteR.SetActive(true);
            AttackCounter = AttackCooldown;

            Collider2D[] howmanyTiles = Physics2D.OverlapCircleAll(attackPosR.position, attackRange, itisTile);
            foreach (Collider2D Tile in howmanyTiles)
            {
                //Debug.Log("hit_R" + Tile.name);

                CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
            }

            Collider2D[] howmanyEnemies = Physics2D.OverlapCircleAll(attackPosR.position, attackRange, itisEnemy);
            foreach (Collider2D Enemy in howmanyEnemies)
            {
                //Debug.Log("hit_RE" + Enemy.name);
                Enemy.GetComponent<EnemyHealth>().Damage(damageAmount);
                CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
            }

            if (PlayerPrefs.GetString("deflect") == "deflect")
            {
                Collider2D[] howmanyprojectiles = Physics2D.OverlapCircleAll(attackPosR.position, attackRange, itisprojectile);
                foreach (Collider2D projectiles in howmanyprojectiles)
                {
                    Debug.Log("hit_RP" + projectiles.name);
                    projectiles.gameObject.SetActive(false);
                    GameObject projectile = Instantiate(PlayerShoot.projectilePrefab, projectiles.transform.position, Quaternion.identity);
                    Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
                    projectileRigidbody.velocity = Vector2.right.normalized * PlayerShoot.projectileSpeed;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }

        //ATTACK LEFT
        if (attackTimeCounterL > 0)
        {
            LeftTrigger = true;
            attackspriteL.SetActive(true);
            AttackCounter = AttackCooldown;

            Collider2D[] howmanyTiles = Physics2D.OverlapCircleAll(attackPosL.position, attackRange, itisTile);
            foreach (Collider2D Tile in howmanyTiles)
            {
                //Debug.Log("hit_L" + Tile.name);

                CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
            }

            Collider2D[] howmanyEnemies = Physics2D.OverlapCircleAll(attackPosL.position, attackRange, itisEnemy);
            foreach (Collider2D Enemy in howmanyEnemies)
            {
                //Debug.Log("hit_LE" + Enemy.name);
                Enemy.GetComponent<EnemyHealth>().Damage(damageAmount);
                CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
            }

            if (PlayerPrefs.GetString("deflect") == "deflect")
            {
                Collider2D[] howmanyprojectiles = Physics2D.OverlapCircleAll(attackPosL.position, attackRange, itisprojectile);
                foreach (Collider2D projectiles in howmanyprojectiles)
                {
                    Debug.Log("hit_LP" + projectiles.name);
                    projectiles.gameObject.SetActive(false);
                    GameObject projectile = Instantiate(PlayerShoot.projectilePrefab, projectiles.transform.position, Quaternion.identity);
                    Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
                    projectileRigidbody.velocity = Vector2.left.normalized * PlayerShoot.projectileSpeed;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }
        }

        //ATTACK DOWN
        if (attackTimeCounterD > 0)
        {
            DownTrigger = true;
            attackspriteD.SetActive(true);
            AttackCounter = AttackCooldown;

            /*Collider2D[] howmanyTiles = Physics2D.OverlapCircleAll(attackPosD.position, attackRange, itisTile);
            foreach (Collider2D Tile in howmanyTiles)
            {
                //Debug.Log("hit_D" + Tile.name);
                CharacterController2D.CoyoteCounter = 0;
                CharacterController2D.m_Grounded = false;
                CharacterController2D.GroundCheckCounter = 0.2f;
                CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
            }*/

            Collider2D[] howmanyEnemies = Physics2D.OverlapCircleAll(attackPosD.position, attackRange, itisEnemy);
            foreach (Collider2D Enemy in howmanyEnemies)
            {
                //Debug.Log("hit_DE" + Enemy.name);
                Enemy.GetComponent<EnemyHealth>().Damage(damageAmount);
                CharacterController2D.CoyoteCounter = 0;
                CharacterController2D.m_Grounded = false;
                CharacterController2D.GroundCheckCounter = 0.2f;
                CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
            }

            if (PlayerPrefs.GetString("deflect") == "deflect")
            {
                Collider2D[] howmanyprojectiles = Physics2D.OverlapCircleAll(attackPosD.position, attackRange, itisprojectile);
                foreach (Collider2D projectiles in howmanyprojectiles)
                {
                    Debug.Log("hit_DP" + projectiles.name);
                    projectiles.gameObject.SetActive(false);
                    GameObject projectile = Instantiate(PlayerShoot.projectilePrefab, projectiles.transform.position, Quaternion.identity);
                    Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
                    projectileRigidbody.velocity = Vector2.down.normalized * PlayerShoot.projectileSpeed;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, -90);

                    CharacterController2D.CoyoteCounter = 0;
                    CharacterController2D.m_Grounded = false;
                    CharacterController2D.GroundCheckCounter = 0.2f;
                    CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
                }
            }
        }

        //ATTACK UP
        if (attackTimeCounterU > 0)
        {
            UpTrigger = true;
            attackspriteU.SetActive(true);
            AttackCounter = AttackCooldown;

            Collider2D[] howmanyTiles = Physics2D.OverlapCircleAll(attackPosU.position, attackRange, itisTile);
            foreach (Collider2D Tile in howmanyTiles)
            {
                //Debug.Log("hit_U" + Tile.name);

                CharacterController2D.KBCounter = CharacterController2D.KBTotalTime;
            }

            Collider2D[] howmanyEnemies = Physics2D.OverlapCircleAll(attackPosU.position, attackRange, itisEnemy);
            foreach (Collider2D Enemy in howmanyEnemies)
            {
                //Debug.Log("hit_UE" + Enemy.name);
                Enemy.GetComponent<EnemyHealth>().Damage(damageAmount);
            }
            if (PlayerPrefs.GetString("deflect") == "deflect")
            {
                Collider2D[] howmanyprojectiles = Physics2D.OverlapCircleAll(attackPosU.position, attackRange, itisprojectile);
                foreach (Collider2D projectiles in howmanyprojectiles)
                {
                    Debug.Log("hit_UP" + projectiles.name);
                    projectiles.gameObject.SetActive(false);
                    GameObject projectile = Instantiate(PlayerShoot.projectilePrefab, projectiles.transform.position, Quaternion.identity);
                    Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
                    projectileRigidbody.velocity = Vector2.up.normalized * PlayerShoot.projectileSpeed;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }
        }

            if (Input.GetKey(KeyCode.RightArrow) && AttackCounter <= 0)
            {
                attackASoundEffect.Play();
                attackTimeCounterR = attackTime;
                playerAnimator.SetTrigger("Attack");
                attackAnimatorR.SetTrigger("Attack_Right");
            }
            else if(Input.GetKey(KeyCode.LeftArrow) && AttackCounter <= 0)
            {
                attackASoundEffect.Play();
                attackTimeCounterL = attackTime;
                playerAnimator.SetTrigger("Attack");
                attackAnimatorL.SetTrigger("Attack_Left");
            }
            else if(Input.GetKey(KeyCode.DownArrow) && AttackCounter <= 0)
            {
                attackASoundEffect.Play();
                attackTimeCounterD = attackTime;
                playerAnimator.SetTrigger("Attack");
                attackAnimatorD.SetTrigger("Attack_Down");
            }
            else if(Input.GetKey(KeyCode.UpArrow) && AttackCounter <= 0)
            {
                attackASoundEffect.Play();
                attackTimeCounterU = attackTime;
                playerAnimator.SetTrigger("Attack");
                attackAnimatorU.SetTrigger("Attack_Up");
            }
        
        attackPosR.transform.position = new Vector3(PlayerPos.position.x + attackPosRL, PlayerPos.position.y, PlayerPos.position.z);
        attackPosL.transform.position = new Vector3(PlayerPos.position.x - attackPosRL, PlayerPos.position.y, PlayerPos.position.z);

        AttackCounter -= Time.deltaTime;
        attackTimeCounterR -= Time.deltaTime;
        attackTimeCounterL -= Time.deltaTime;
        attackTimeCounterD -= Time.deltaTime;
        attackTimeCounterU -= Time.deltaTime;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosR.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPosL.position, attackRange);
    }
}
