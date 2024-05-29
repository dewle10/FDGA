using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public int currentHealth;
    public int startingHealth;
    public int heartsCount;

    public GameObject emptyPlayer;
    public GameObject cameraEmptyPlayer;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    public SimpleFlash simpleFlash;
    public PlayerInfo playerInfo;

    private void Awake()
    {
        LoadData();

        currentHealth = startingHealth;
        simpleFlash = GetComponent<SimpleFlash>();
    }
    private void Start()
    {
        startingHealth = playerInfo.playerStartingHealth;
        currentHealth = playerInfo.playerCurrentHealth;
        transform.position = new Vector3(playerInfo.playerPositionX, playerInfo.playerPositionY, 0);
    }

    public void TakeDamage(int _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (simpleFlash != null)
        {
            simpleFlash.Flash();
        }
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }


            if (i < startingHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void Death()
    {
        Instantiate(cameraEmptyPlayer, new Vector3(transform.position.x, transform.position.y,-10f), Quaternion.identity);
        Instantiate(emptyPlayer, transform.position, Quaternion.identity);
        playerInfo.numberOfFogToTurnOff = playerInfo.numberOfSaveFog;
        playerInfo.playerPositionX = playerInfo.lastSavePositionX;
        playerInfo.playerPositionY = playerInfo.lastSavePositionY;
        gameObject.SetActive(false);
    }

    public void LoadData()
    {
        PlayerData playerData = SaveSystem.LoadPlayer();

        playerInfo.playerCurrentHealth = playerData.playerCurrentHealth;
        playerInfo.playerStartingHealth = playerData.playerStartingHealth;
        playerInfo.playerMaxAmmo = playerData.playerMaxAmmo;
        playerInfo.playerPositionX = playerData.playerPositionX;
        playerInfo.playerPositionY = playerData.playerPositionY;
        playerInfo.heartsCount = playerData.heartsCount;
        playerInfo.numberOfFogToTurnOff = playerData.numberOfFogToTurnOff;
        playerInfo.numberOfSaveFog = playerData.numberOfSaveFog;
        playerInfo.flipONStart = playerData.flipONStart;
        playerInfo.lastSaveScene = playerData.lastSaveScene;
        playerInfo.lastSavePositionX = playerData.lastSavePositionX;
        playerInfo.lastSavePositionY = playerData.lastSavePositionY;
    }
}
