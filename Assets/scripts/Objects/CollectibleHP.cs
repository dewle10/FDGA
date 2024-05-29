using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleHP : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerInfo playerInfo;
    public GameObject player;
    public AudioSource audioSource;
    public ParticleSystem particle;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            particle.Play();
            audioSource.Play();
            gameObject.SetActive(false);
            playerHealth.currentHealth = Mathf.Clamp(playerHealth.currentHealth + 1, 0, playerHealth.startingHealth);
            playerInfo.playerCurrentHealth = Mathf.Clamp(playerInfo.playerCurrentHealth + 1, 0, playerInfo.playerStartingHealth);

        }
    }
}
