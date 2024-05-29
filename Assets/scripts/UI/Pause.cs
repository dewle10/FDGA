using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Pause : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public GameObject pausePanel;
    public TextMeshProUGUI text;
    public bool paused;
    private Map map;

    private void Start()
    {
        map = GetComponent<Map>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !map.mapOn)
        {
            if (!paused)
            {
                AudioListener.pause = true;
                text.text = playerInfo.heartsCount.ToString();
                Time.timeScale = 0;
                paused = true;
                pausePanel.SetActive(true);
            }
            else if (paused)
            {
                AudioListener.pause = false;
                Time.timeScale = 1;
                paused = false;
                pausePanel.SetActive(false);
            }
        }

    }
    public void Menu()
    {
        playerInfo.numberOfFogToTurnOff = playerInfo.numberOfSaveFog;
        SaveSystem.SavePlayer(playerInfo);
        AudioListener.pause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
