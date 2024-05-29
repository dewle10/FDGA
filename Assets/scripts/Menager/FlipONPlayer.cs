using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipONPlayer : MonoBehaviour
{
    public GameObject flipingObject;
    public bool negativeFlip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (negativeFlip && flipingObject.transform.localScale.x > 0)
            {
                Vector3 localScale = flipingObject.transform.localScale;
                localScale.x *= -1;
                flipingObject.transform.localScale = localScale;
            }
            if (!negativeFlip && flipingObject.transform.localScale.x < 0)
            {
                Vector3 localScale = flipingObject.transform.localScale;
                localScale.x *= -1;
                flipingObject.transform.localScale = localScale;
            }
        }
    }
}