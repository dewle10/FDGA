using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMeg : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public Sceneinfo sceneinfo;
    public GameObject[] fog;
    void Awake()
    {
        if (sceneinfo.fogToTurnOff != null && playerInfo.numberOfFogToTurnOff == 0)
        {
            sceneinfo.fogToTurnOff.SetActive(false);
        }
        else for (int i = 1; i < fog.Length; ++i)
        {
            if(playerInfo.numberOfFogToTurnOff == i)
            {
                fog[i].SetActive(false);
            }
        }
    }
}
