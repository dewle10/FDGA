using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public FogOfWar FogOfWar;
    public int exit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FogOfWar.whatExit = exit;
        }
    }
}
