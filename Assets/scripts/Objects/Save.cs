using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public PlayerData playerData;
    public PlayerInfo playerInfo;
    public PlayerHealth playerHealth;
    public GameObject player;
    public PlayerShoot playerShoot;
    public ParticleSystem ParticleSystem;
    public GameObject[] enemies;
    public int fogNumber;
    public GameObject fog;
    public int scenenumber;
    public int mapnumber;
    public Map map;
    private EnemyHealth enemyHealth;
    private SimpleFlash simpleFlash;
    //public string sceneName;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerShoot = player.GetComponent<PlayerShoot>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //StartCoroutine(Reload());
            playerHealth.currentHealth = playerHealth.startingHealth;
            playerInfo.playerCurrentHealth = playerHealth.currentHealth;
            playerInfo.playerStartingHealth = playerHealth.startingHealth;
            playerInfo.playerMaxAmmo = playerShoot.maxAmmo;
            playerInfo.playerPositionX = gameObject.transform.position.x;
            playerInfo.playerPositionY = gameObject.transform.position.y;
            playerInfo.numberOfSaveFog = fogNumber;
            playerInfo.lastSaveScene = scenenumber;
            playerInfo.lastSavePositionX = gameObject.transform.position.x;
            playerInfo.lastSavePositionY = gameObject.transform.position.y;

            PlayerPrefs.SetInt("map" + mapnumber.ToString(), mapnumber);
            map.mapPieces[mapnumber].SetActive(true);
            map.smallMapPieces[mapnumber].SetActive(true);

            ParticleSystem.Play();
            SaveSystem.SavePlayer(playerInfo);

            for (int i = 0; i < enemies.Length; ++i)
            {
                enemies[i].SetActive(true);
                enemyHealth = enemies[i].GetComponent<EnemyHealth>();
                enemyHealth.currentHealth = enemyHealth.startingHealth;
                enemyHealth.hit = false;
                simpleFlash = enemies[i].GetComponent<SimpleFlash>();
                simpleFlash.Flash();
            }
        }
    }
    //private IEnumerator Reload()
    //{
        //yield return new WaitForSeconds(1f);
        //SceneManager.LoadScene(sceneName);
    //}
}

