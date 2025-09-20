using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab to be shot
    public float projectileSpeed = 10f; // The speed of the projectile
    public float fireRate = 0.5f; // The rate of fire in seconds
    public float reloadTime = 5f;
    public float maxAmmo = 2f;
    public float currentAmmo;
    [SerializeField] private float reloadCounter;

    public Image[] ammo;
    public Sprite fullAmmo;
    public Sprite emptyAmmo;

    private float lastFiredTime = 0f; // The time when the player last fired a projectile

    public CharacterController2D CharacterController2D;

    [SerializeField] private AudioSource shootSoundEffect;

    public PlayerInfo playerInfo;

    private void Start()
    {
        maxAmmo = playerInfo.playerMaxAmmo;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.Keypad0) && Time.time > lastFiredTime + fireRate && currentAmmo > 0)
        {
            lastFiredTime = Time.time;
            Shoot();
            currentAmmo -= 1;
        }

        if(currentAmmo < maxAmmo)
        {
            reloadCounter += Time.deltaTime;
            if(reloadCounter >= reloadTime)
            {
                currentAmmo += 1;
                reloadCounter = 0;
            }
        }
        
        for (int i = 0; i < ammo.Length; i++)
        {
            if (i < currentAmmo)
            {
                ammo[i].sprite = fullAmmo;
            }
            else
            {
                ammo[i].sprite = emptyAmmo;
            }


            if (i < maxAmmo)
            {
                ammo[i].enabled = true;
            }
            else
            {
                ammo[i].enabled = false;
            }
        }
    }

    void Shoot()
    {
        if(PlayerPrefs.GetString("shoot") == "shoot")
        {
            // Create a new projectile instance
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            shootSoundEffect.Play();

            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            if (projectileRigidbody != null)
            {
                Vector2 direction = Vector2.zero;
                if (Input.GetKey(KeyCode.W))
                {
                    direction = Vector2.up;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    direction = Vector2.down;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, -90);
                }
                else if (CharacterController2D.m_FacingRight == true)
                {
                   direction = Vector2.right;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    direction = Vector2.left;
                    projectile.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            
                projectileRigidbody.velocity = direction.normalized * projectileSpeed;
            }
        }
    }
}