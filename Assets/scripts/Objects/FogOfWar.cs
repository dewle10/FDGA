using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    public GameObject fog1;
    public GameObject fog2;
    public GameObject door;
    public int whatExit;
        
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            door.SetActive(false);
            fog1.SetActive(false);
            fog2.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(whatExit == 1)
            {
                fog1.SetActive(false);
                door.SetActive(true);
                fog2.SetActive(true);
            }

            if (whatExit == 2)
            {
                fog2.SetActive(false);
                door.SetActive(true);
                fog1.SetActive(true);
            }
        }
    }
}
