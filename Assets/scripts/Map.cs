using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject[] mapPieces;
    public GameObject[] smallMapPieces;
    public GameObject mapPanel;
    private Pause pause;
    public bool mapOn;
    public GameObject bigMap;
    public bool bigMapOn;
    public GameObject smallMap;
    public bool smallMapOn;
    public int smallMapNumber;

    public GameObject smallMapBlue;
    public GameObject smallMapGreen;
    public GameObject smallMapRed;
    public GameObject smallMapYellow;
    public GameObject smallMapPurple;
    public GameObject smallMapOrange;

    void Start()
    {
        pause = GetComponent<Pause>();

        for (int i = 1; i < mapPieces.Length; ++i)
        {
            if (PlayerPrefs.GetInt("map" + i.ToString()) == i)
            {
                mapPieces[i].SetActive(true);
                smallMapPieces[i].SetActive(true);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !pause.paused)
        {
            if (!mapOn)
            {
                AudioListener.pause = true;
                Time.timeScale = 0;
                mapOn = true;
                mapPanel.SetActive(true);
            }
            else if (mapOn)
            {
                AudioListener.pause = false;
                Time.timeScale = 1;
                mapOn = false;
                mapPanel.SetActive(false);
            }

        }
        if(mapOn && Input.GetKeyDown(KeyCode.S) && bigMapOn)
        {
            bigMapOn = false;
            bigMap.SetActive(false);
            smallMapOn = true;
            smallMap.SetActive(true);
            SnallMapCheck();
        }
        if(mapOn && Input.GetKeyDown(KeyCode.W) && smallMapOn)
        {
            smallMapOn = false;
            smallMap.SetActive(false);
            bigMapOn = true;
            bigMap.SetActive(true);
        }
        if(mapOn && smallMapOn)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                smallMapNumber -= 1;

                if (smallMapNumber == -1)
                {
                    smallMapNumber = 5;
                }
                SnallMapCheck();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                smallMapNumber += 1;

                if(smallMapNumber == 6)
                {
                    smallMapNumber = 0;
                }
                SnallMapCheck();
            }
        }
    }
    void SnallMapCheck()
    {
        //Blue
        if (smallMapNumber == 0)
        {
            smallMapBlue.SetActive(true);
            smallMapGreen.SetActive(false);
            smallMapRed.SetActive(false);
            smallMapYellow.SetActive(false);
            smallMapPurple.SetActive(false);
            smallMapOrange.SetActive(false);
        }
        //Green
        if (smallMapNumber == 1)
        {
            smallMapBlue.SetActive(false);
            smallMapGreen.SetActive(true);
            smallMapRed.SetActive(false);
            smallMapYellow.SetActive(false);
            smallMapPurple.SetActive(false);
            smallMapOrange.SetActive(false);
        }
        //Red
        if (smallMapNumber == 2)
        {
            smallMapBlue.SetActive(false);
            smallMapGreen.SetActive(false);
            smallMapRed.SetActive(true);
            smallMapYellow.SetActive(false);
            smallMapPurple.SetActive(false);
            smallMapOrange.SetActive(false);
        }
        //Yellow
        if (smallMapNumber == 3)
        {
            smallMapBlue.SetActive(false);
            smallMapGreen.SetActive(false);
            smallMapRed.SetActive(false);
            smallMapYellow.SetActive(true);
            smallMapPurple.SetActive(false);
            smallMapOrange.SetActive(false);
        }
        //Purple
        if (smallMapNumber == 4)
        {
            smallMapBlue.SetActive(false);
            smallMapGreen.SetActive(false);
            smallMapRed.SetActive(false);
            smallMapYellow.SetActive(false);
            smallMapPurple.SetActive(true);
            smallMapOrange.SetActive(false);
        }
        //Orange
        if (smallMapNumber == 5)
        {
            smallMapBlue.SetActive(false);
            smallMapGreen.SetActive(false);
            smallMapRed.SetActive(false);
            smallMapYellow.SetActive(false);
            smallMapPurple.SetActive(false);
            smallMapOrange.SetActive(true);
        }
    }
}
