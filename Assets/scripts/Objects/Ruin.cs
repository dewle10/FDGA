using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruin : MonoBehaviour
{
    public GameObject ruin;
    public GameObject breakableObject;
    public GameObject secretFog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && ruin.activeSelf)
        {
            ruin.SetActive(false);
            breakableObject.SetActive(true);
            secretFog.SetActive(true);
        }
        if (collision.CompareTag("Player") && breakableObject.activeSelf)
        {
            secretFog.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        secretFog.SetActive(false);
    }
}
