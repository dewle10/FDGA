using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playerCurrentHealth = 3;
    public int playerStartingHealth = 3;
    public float playerMaxAmmo = 0;
    public float playerPositionX = -12.25f;
    public float playerPositionY = -0.75f;
    public bool haveDash;
    public bool haveDeflect;
    public bool haveDoubleJump;
    public bool haveShoot;
    public int heartsCount;
    public int numberOfFogToTurnOff;
    public int numberOfSaveFog;
    public bool flipONStart;
    public int lastSaveScene;
    public float lastSavePositionX;
    public float lastSavePositionY;

    public PlayerData (PlayerInfo playerInfo)
    {
        playerCurrentHealth = playerInfo.playerCurrentHealth;
        playerStartingHealth = playerInfo.playerStartingHealth;
        playerMaxAmmo = playerInfo.playerMaxAmmo;
        playerPositionX = playerInfo.playerPositionX;
        playerPositionY = playerInfo.playerPositionY;
        heartsCount = playerInfo.heartsCount;
        numberOfFogToTurnOff = playerInfo.numberOfFogToTurnOff;
        numberOfSaveFog = playerInfo.numberOfSaveFog;
        flipONStart = playerInfo.flipONStart;
        lastSaveScene = playerInfo.lastSaveScene;
        lastSavePositionX = playerInfo.lastSavePositionX;
        lastSavePositionY = playerInfo.lastSavePositionY;
    }
}
