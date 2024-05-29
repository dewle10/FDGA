using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrekableObject : MonoBehaviour
{
    public float respawnCounter;
    public float openCounter;
    public float closeCounter;
    public float closeTime;
    public float openTime;
    public EnemyHealth EnemyHealth;
    public GameObject brekableObject;
    public bool Respawning;
    public bool closing;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D objectCollider;

    private void Start()
    {
        if (closing) 
        {
            spriteRenderer = brekableObject.GetComponent<SpriteRenderer>();
            objectCollider = brekableObject.GetComponent<BoxCollider2D>();
            StartCoroutine(Close()); 
        }
        
    }
    void Update()
    {
        if (Respawning) 
        { 
            respawnCounter -= Time.deltaTime;
            if(respawnCounter <= 0)
            {
                brekableObject.SetActive(true);
            }
        }
    }
    private IEnumerator Open()
    {
        yield return new WaitForSeconds(closeTime);
        objectCollider.enabled = !objectCollider.enabled;
        spriteRenderer.color = new Color(0, 0.3530974f, 1, 1);
        //brekableObject.SetActive(true);
        StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(openTime);
        objectCollider.enabled = !objectCollider.enabled;
        //brekableObject.SetActive(false);
        spriteRenderer.color = new Color(0, 0.3530974f, 1, 0.3f);
        StartCoroutine(Open());
    }
}
