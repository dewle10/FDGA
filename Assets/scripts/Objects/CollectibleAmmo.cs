using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAmmo : MonoBehaviour
{
    public PlayerShoot PlayerShoot;
    public PlayerInfo playerInfo;

    public GameObject player;

    public AudioSource audioSource;
    public ParticleSystem particle;

    public CollectiblesList collectiblesList;
    public int collectibleNumber;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerShoot = player.GetComponent<PlayerShoot>();
        if (PlayerPrefs.GetInt(collectibleNumber.ToString()) == collectibleNumber)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            particle.Play();
            audioSource.Play();
            PlayerPrefs.SetInt(collectibleNumber.ToString(), collectibleNumber);
            PlayerShoot.maxAmmo += 1;
            playerInfo.playerMaxAmmo += 1;
            gameObject.SetActive(false);
        }
    }
}
