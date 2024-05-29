using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemeg : MonoBehaviour
{
    public int sceneBuildIndex;
    public float nextScenePosX;
    public float nextScenePosY;
    public bool flip;
    public int fogNumber;

    public PlayerInfo playerInfo;
    public GameObject[] enemies;
    public EnemiesScene1 enemiesScene;

    private PlayerHealth playerHealth;
    private GameObject player;
    private PlayerShoot playerShoot;
    //private EnemyHealth enemyHealth;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerShoot = player.GetComponent<PlayerShoot>();
    }

    /*private void Awake()
    {
        for (int i = 0; i < enemies.Length; ++i)
        {
            enemyHealth = enemies[i].GetComponent<EnemyHealth>();
            enemyHealth.dead = enemiesScene.isDead[i];
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInfo.playerCurrentHealth = playerHealth.currentHealth;
            playerInfo.playerStartingHealth = playerHealth.startingHealth;
            playerInfo.playerMaxAmmo = playerShoot.maxAmmo; 
            playerInfo.playerPositionX = nextScenePosX;
            playerInfo.playerPositionY = nextScenePosY;
            playerInfo.numberOfFogToTurnOff = fogNumber;
            SaveSystem.SavePlayer(playerInfo);

            /*for (int i = 0; i < enemies.Length; ++i)
            {
                enemyHealth = enemies[i].GetComponent<EnemyHealth>();
                enemiesScene.isDead[i] = enemyHealth.dead;
            }*/
            if (flip)
            {
                playerInfo.flipONStart = true;
            }
            else
            {
                playerInfo.flipONStart = false;
            }
            SceneManager.LoadScene(sceneBuildIndex + 1);
        }
    }
}