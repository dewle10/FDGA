using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKillCounter : MonoBehaviour
{
    public int bossKill;
    public int killAmount;
    public GameObject door;
    public GameObject platforms;
    public AudioSource openDoorSoundEffect;
    public int collectibleNumber;

    public void BossCheck()
    {
        if(bossKill >= killAmount)
        {
            openDoorSoundEffect.Play();
            door.SetActive(false);
            platforms.SetActive(true);
            PlayerPrefs.SetInt(collectibleNumber.ToString(), collectibleNumber);
        }
    }
}
