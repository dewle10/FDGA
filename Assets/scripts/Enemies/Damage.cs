using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool teleporting;
    public Transform teleportPoint;
    [SerializeField] private int damage;

    private bool DamageTrigger = false;
    private bool HitFromRight;
    private bool HitFromup;
    private GameObject player;
    private PlayerHealth playerHealth;
    private CharacterController2D controller;
    private void Start()
    {
        GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        controller = player.GetComponent<CharacterController2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            if (teleporting)
            {
                collision.transform.position = teleportPoint.position;
            }
            if(controller.DamageCounter <= 0 && GetComponent<EnemyHealth>().damaging) 
            { 
                DamageTrigger = true;
                controller.KBDamageCounter = controller.KBDamageTime;
                playerHealth.TakeDamage(damage);
                controller.DamageCounter = controller.InvincibilityTime;
                //Debug.Log("damage");
                if (collision.transform.position.x <= transform.position.x)
                {
                    HitFromRight = true; 
                }
                if (collision.transform.position.x > transform.position.x)
                {
                    HitFromRight = false;
                }
                if (collision.transform.position.y <= transform.position.y)
                {
                    HitFromup = true;
                }
                if (collision.transform.position.y > transform.position.y)
                {
                    HitFromup = false;
                }
            }
        }
    }
    private void Update()
    {
        if (!teleporting)
        {
            if (DamageTrigger == true && controller.KBDamageCounter >= 0)
            {
                if (HitFromRight == true && HitFromup == false)
                {
                controller.m_Rigidbody2D.velocity = new Vector2(-controller.KBForceDam, controller.KBForceDam * 0.7f);
                }
                if(HitFromRight == false && HitFromup == false)
                {
                    controller.m_Rigidbody2D.velocity = new Vector2(controller.KBForceDam, controller.KBForceDam * 0.7f);
                }
                if (HitFromRight == true && HitFromup == true)
                {
                    controller.m_Rigidbody2D.velocity = new Vector2(-controller.KBForceDam, -controller.KBForceDam * 0.7f);
                }
                if (HitFromRight == false && HitFromup == true)
                {
                    controller.m_Rigidbody2D.velocity = new Vector2(controller.KBForceDam, -controller.KBForceDam * 0.7f);
                }
            }
        }

        if (controller.DamageCounter <= 0)
        {
            DamageTrigger = false;
        }
        controller.KBDamageCounter -= Time.deltaTime;
    }
}
