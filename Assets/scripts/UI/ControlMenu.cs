using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public void Play()
    {
        if(playerInfo.lastSavePositionX != 0 && playerInfo.lastSavePositionY != 0)
        {
            playerInfo.playerPositionX = playerInfo.lastSavePositionX;
            playerInfo.playerPositionY = playerInfo.lastSavePositionY;
            playerInfo.numberOfFogToTurnOff = playerInfo.numberOfSaveFog;
        }

        SaveSystem.SavePlayer(playerInfo);
        SceneManager.LoadScene(playerInfo.lastSaveScene + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();

        playerInfo.playerCurrentHealth = 4;
        playerInfo.playerStartingHealth = 4;
        playerInfo.playerMaxAmmo = 0;
        playerInfo.playerPositionX = -12.25f;
        playerInfo.playerPositionY = -0.75f;
        playerInfo.heartsCount = 0;
        playerInfo.numberOfFogToTurnOff = 0;
        playerInfo.numberOfSaveFog = 0;
        playerInfo.flipONStart = false;
        playerInfo.lastSaveScene = 0;
        playerInfo.lastSavePositionX = 0;
        playerInfo.lastSavePositionY = 0;
    }
}
