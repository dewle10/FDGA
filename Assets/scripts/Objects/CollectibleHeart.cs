using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHeart : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerInfo playerInfo;
    public GameObject player;

    public AudioSource audioSource;
    public ParticleSystem particle;

    public CollectiblesList collectiblesList;
    public int collectibleNumber;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
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
            playerInfo.heartsCount += 1;
            if(playerInfo.heartsCount == 3)
            {
                playerInfo.heartsCount = 0;
                playerHealth.startingHealth += 1;
                playerInfo.playerStartingHealth += 1;
            }
            gameObject.SetActive(false);
        }
    }
}
