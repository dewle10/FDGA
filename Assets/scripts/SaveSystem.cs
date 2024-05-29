using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void SavePlayer(PlayerInfo playerInfo)
    {
        string path = Path.Combine(Application.persistentDataPath, "player.json");

        try
        {
            PlayerData data = new PlayerData(playerInfo);
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }
        catch (IOException e)
        {
            Debug.LogError("Failed to save player data to " + path + " with exception: " + e);
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.json");

        if (File.Exists(path))
        {
            try
            {
                string json = File.ReadAllText(path);
                PlayerData data = JsonUtility.FromJson<PlayerData>(json);
                return data;
            }
            catch (IOException e)
            {
                Debug.LogError("Failed to load player data from " + path + " with exception: " + e);
                return null;
            }
        }
        else
        {
            Debug.LogError("Save file not found: " + path);
            return null;
        }
    }
}
