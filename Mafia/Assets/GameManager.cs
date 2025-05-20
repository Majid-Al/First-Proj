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
}
