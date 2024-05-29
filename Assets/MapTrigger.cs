using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTrigger : MonoBehaviour
{
    public int mapnumber;
    public Map map;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("map" + mapnumber.ToString(), mapnumber);
            map.smallMapPieces[mapnumber].SetActive(true);
            map.mapPieces[mapnumber].SetActive(true);
        }
    }
}
