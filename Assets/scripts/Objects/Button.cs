using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject door;
    public SpriteRenderer SpriteRenderer;
    public Sprite offSprite;
    public AudioSource openDoorSoundEffect;
    public AudioSource closeDoorSoundEffect;
    private bool isPlayerIn;
    public bool doorOpen;
    public bool notcollectible;

    public CollectiblesList buttonsList;
    public int collectibleNumber;

    private void Start()
    {
        if (!notcollectible)
        {
            if (PlayerPrefs.GetInt(collectibleNumber.ToString()) == collectibleNumber)
            {
                SpriteRenderer.sprite = offSprite;
                if (doorOpen)
                {
                    door.SetActive(true);
                }
                else
                {
                    door.SetActive(false);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerIn = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerIn = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerIn)
        {
            SpriteRenderer.sprite = offSprite;
            if (doorOpen)
            {
                door.SetActive(true);
                openDoorSoundEffect.Play();
                PlayerPrefs.SetInt(collectibleNumber.ToString(), collectibleNumber);
            }
            else
            {
                door.SetActive(false);
                closeDoorSoundEffect.Play();
                PlayerPrefs.SetInt(collectibleNumber.ToString(), collectibleNumber);
            }
        }
    }
}
