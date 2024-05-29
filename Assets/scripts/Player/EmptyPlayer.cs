using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmptyPlayer : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public ParticleSystem particle;
    void Awake()
    {
        StartCoroutine(LoadScene());
    }
    private IEnumerator LoadScene()
    {
        particle.Play();
        playerInfo.playerPositionX = playerInfo.lastSavePositionX;
        playerInfo.playerPositionY = playerInfo.lastSavePositionY;
        SaveSystem.SavePlayer(playerInfo);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(playerInfo.lastSaveScene + 1);
    }
}
