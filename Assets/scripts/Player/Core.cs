using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject emptyPlayer;
    public GameObject player;
    public GameObject playerCamera;
    public GameObject newCamera;
    public ParticleSystem ParticleSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            newCamera.transform.position = playerCamera.transform.position;
            emptyPlayer.transform.position = player.transform.position;
            spriteRenderer.enabled = true;
            emptyPlayer.SetActive(true);
            newCamera.SetActive(true);
            player.SetActive(false);
            ParticleSystem.Play();
        }
    }
}
