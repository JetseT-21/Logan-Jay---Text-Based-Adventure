using System;
using System.IO;
using UnityEngine;

public static class SaveManager
{
    private static readonly string PathToFile = Application.persistentDataPath + "/GameSaveFile.json";

    public static void Save(GameData data)
    {
        data.Version = Application.version;
        data.LastSaved = DateTime.UtcNow.ToString(format: "o");
        
        string json = JsonUtility.ToJson(data,prettyPrint: true);
        File.WriteAllText(PathToFile, contents:json);
        Debug.Log($"[SaveManager] saved game data to {PathToFile}");
    }

    public static GameData Load()
    {
        TryLoad(out GameData data);
        return data;
    }

    public static bool TryLoad(out GameData data)
    {
        try
        {
            if (!File.Exists(PathToFile))
            {
                data = new GameData();
                return false;
            }

            string json = File.ReadAllText(PathToFile);
            data = JsonUtility.FromJson<GameData>(json);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError($"[SaveManager] Load Failed: {e.Message}");
            data = new GameData();
            return false;
        }
    }

}
