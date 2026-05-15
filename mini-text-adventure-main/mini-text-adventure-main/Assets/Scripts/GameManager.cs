using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player;
    private GameData _currentData = new();

    public void SaveGame()
    {
        _currentData.Player = Player.ToData();
        SaveManager.Save(_currentData);
        Debug.Log("Game Saved!");   
    }


    public void LoadGame()
    {
        if (SaveManager.TryLoad(out _currentData))
        {
            Player.FromData(_currentData.Player);
            Debug.Log("Game Loaded!");
        }
        else
        {
            Debug.LogWarning("No save file found. Starting a new one.");
            SaveGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    private void Start()
    {
        LoadGame();
    }
}