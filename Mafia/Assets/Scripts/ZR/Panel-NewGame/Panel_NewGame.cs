using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Panel_NewGame : MonoBehaviour
{
    [SerializeField] private PlayerPriiview playerPreview;
    [SerializeField] private Transform content;
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private List<string> listPlayerName;
    [SerializeField] private Panel_Roles Panel_Roles;
    [SerializeField] private GameObject Popup_Warning;
    [SerializeField] private List<Sprite> availableImages;
    [SerializeField] private Button nextButton;
    private List<Sprite> unAvailableImages = new List<Sprite>();
    private int playerCount;
    private void Start()
    {
        unAvailableImages=new List<Sprite>(availableImages);
        playerCount = PlayerPrefs.GetInt("SavedPlayerCount", 0);
        GameManager.Instance.RestoreSavedPlayers(this);

   }
    private void Update()
    {
        int Count = GameManager.Instance.playerNames.Count;
        bool Next = Count > 5;
        nextButton.interactable = (Next);
    }
    public void AddPlayer()
    {
        string playerName = inputName.text;
        if (string.IsNullOrEmpty(playerName))
            return;
        foreach(var playerNames in GameManager.Instance.players)
        {
            if(playerNames.name == playerName)
            {
                Popup_Warning.SetActive(true);
                return;
            }
        }

        if (unAvailableImages.Count == 0)
            unAvailableImages = new List<Sprite>(availableImages);

        playerCount++;
        int index = Random.Range(0, unAvailableImages.Count);
        Sprite selectedSprite = unAvailableImages[index];
        unAvailableImages.RemoveAt(index);

        var player = Instantiate(playerPreview, content);
        player.Setup(playerName, selectedSprite, playerCount);

        GameManager.Instance.playerNames.Add(playerName);
        GameManager.Instance.players.Add(new PlayerData(playerName, selectedSprite));
        inputName.text = "";


        string nameKey = "Player" + playerCount + "_Name";
        string avatarKey = "Player" + playerCount + "_Avatar";
        PlayerPrefs.SetString(nameKey, playerName);
        PlayerPrefs.SetInt(avatarKey, index);
        PlayerPrefs.SetInt("SavedPlayerCount", playerCount);

    }
    public void AddPlayer(string playerName, int avatarIndex,int playerSaveIndex)
    {
        if (playerName == "none")
            return;


        if (unAvailableImages.Count == 0)
            unAvailableImages = new List<Sprite>(availableImages);

        Sprite selectedSprite = unAvailableImages[avatarIndex];
        unAvailableImages.RemoveAt(avatarIndex);

        var player = Instantiate(playerPreview, content);
        player.Setup(playerName, selectedSprite, playerSaveIndex);

        GameManager.Instance.playerNames.Add(playerName);
        GameManager.Instance.players.Add(new PlayerData(playerName, selectedSprite));

        inputName.text = "";
    }
    public void RemoveList(string name)
    {
        listPlayerName.Remove(name);
        foreach (var player in GameManager.Instance.players)
        {
            if (player.name == name)
            {
                GameManager.Instance.players.Remove(player);
            }
        }
        if(GameManager.Instance.players.Count < 1)
        {
            PlayerPrefs.SetInt("SavedPlayerCount", 0);
        }
    }
    public void NextButton()
    {

        if (listPlayerName.Count < 5)
        {
            Debug.Log("Player Count HaveTo be More than 5");
            this.gameObject.SetActive(false);
            Panel_Roles.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("It  is Ok");
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string name;
    public Sprite avatar;

    public PlayerData(string name, Sprite avatar)
    {
        this.name = name;
        this.avatar = avatar;
    }
}
