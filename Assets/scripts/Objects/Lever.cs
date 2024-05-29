using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;
    [SerializeField] private bool openDoor = false;
    public SpriteRenderer SpriteRenderer;
    public AudioSource openDoorSoundEffect;
    public AudioSource closeDoorSoundEffect;
    private bool isPlayerIn;
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
            if (openDoor == false)
            {
                openDoorSoundEffect.Play();
                door.SetActive(false);
                openDoor = true;
                Flip();
            }
            else
            {
                closeDoorSoundEffect.Play();
                door.SetActive(true);
                openDoor = false;
                Flip();
            }
        }
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
