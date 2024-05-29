using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "PInfo")]
public class PlayerInfo : ScriptableObject

{
    public int playerCurrentHealth = 3;
    public int playerStartingHealth = 3;
    public float playerMaxAmmo = 0;
    public float playerPositionX = -12.25f;
    public float playerPositionY = -0.75f;
    public int heartsCount;
    public int numberOfFogToTurnOff;
    public int numberOfSaveFog;
    public bool flipONStart;
    public int lastSaveScene;
    public float lastSavePositionX;
    public float lastSavePositionY;
}
