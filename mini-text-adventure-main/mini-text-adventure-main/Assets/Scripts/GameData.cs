[System.Serializable]

public class GameData
{
   public string Version = "v1.0";
   public string LastSaved;
   public PlayerData Player = new();
}
