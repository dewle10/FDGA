using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAbility : MonoBehaviour
{
    public bool dash;
    public bool doubleJump;
    public bool shoot;
    public bool deflect;

    public PlayerInfo playerInfo;
    public GameObject player;
    public PlayerShoot playerShoot;

    public CollectiblesList collectiblesList;
    public int collectibleNumber;
    public int mapnumber;
    public Map map;

    public ParticleSystem particle;
    public AudioSource audioSource;

    private void Start()
    {
        if (PlayerPrefs.GetInt(collectibleNumber.ToString()) == collectibleNumber)
        {
            gameObject.SetActive(false);
        }
        player = GameObject.FindGameObjectWithTag("Player");
        playerShoot = player.GetComponent<PlayerShoot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            particle.Play();

            map.smallMapPieces[mapnumber].SetActive(true);
            map.mapPieces[mapnumber].SetActive(true);
            PlayerPrefs.SetInt("map" + mapnumber.ToString(), mapnumber);

            PlayerPrefs.SetInt(collectibleNumber.ToString(), collectibleNumber);
            if (dash)
            {
                PlayerPrefs.SetString("dash", "dash");
            }
            else if (doubleJump)
            {
                PlayerPrefs.SetString("doubleJump", "doubleJump");
            }
            else if (shoot)
            {
                PlayerPrefs.SetString("shoot", "shoot");
                playerInfo.playerMaxAmmo += 1;
                playerShoot.maxAmmo += 1;
            }
            else if (deflect)
            {
                PlayerPrefs.SetString("deflect", "deflect");
            }
            gameObject.SetActive(false);
        }
    }
}
