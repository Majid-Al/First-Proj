using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<string> playerNames = new List<string>();
    public List<RoleItem> selectedRoles = new List<RoleItem>();
    public List<PlayerData> players = new List<PlayerData>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    public void RestoreSavedPlayers(Panel_NewGame panel_NewGame)
    {

        int playerCount = PlayerPrefs.GetInt("SavedPlayerCount", 0);
        for (int i = 1; i <= playerCount; i++)
        {
            Debug.Log("Majid for loop count : " + i);
            string nameKey = "Player" + i.ToString() + "_Name";
            string avatarKey = "Player" + i.ToString() + "_Avatar";

            string name = PlayerPrefs.GetString(nameKey, "none");
            int avatarInt = PlayerPrefs.GetInt(avatarKey, -1);
            panel_NewGame.AddPlayer(name, avatarInt,i);
            Debug.Log("Player Name: " + name);
            Debug.Log("Player Avatar Index: " + avatarInt);
        }

    }

    public void SavePlayer(string playerName,int avatarIndex)
    {

    }
}
