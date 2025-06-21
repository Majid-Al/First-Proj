using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Panel_Roles Panel_Roles;
    public List<RoleItem> selectedRoles = new List<RoleItem>();
    public List<PlayerData> players = new List<PlayerData>();

    public void RemovePlayer(string playerName)
    {
        players.RemoveAll(p => p.name == playerName);
    }

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

    [SerializeField] private GameObject musicButton;
    Image musicButtonImage;
    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(WaitAndPlayNext());
        musicButtonImage = musicButton.GetComponent<Image>();
    }

    public void RestoreSavedPlayers(Panel_NewGame panel_NewGame)
    {

        int playerCount = PlayerPrefs.GetInt("SavedPlayerCount", 0);
        for (int i = 1; i <= playerCount; i++)
        {
            string nameKey = "Player" + i.ToString() + "_Name";
            string avatarKey = "Player" + i.ToString() + "_Avatar";

            string name = PlayerPrefs.GetString(nameKey, "none");
            int avatarInt = PlayerPrefs.GetInt(avatarKey, -1);
            panel_NewGame.AddPlayer(name, avatarInt,i);
        }

    }

    public void SavePlayer(string playerName,int avatarIndex)
    {

    }

    //Audio section
    [SerializeField] private AudioClip[] clips;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] private Sprite audioImageOn,audioImageOff;
    bool mute = false;
    public void MusicButtonToggle()
    {
        if (mute)
        {
            musicAudioSource.mute = false;
            musicButtonImage.sprite = audioImageOn;
            mute = false;
        }
        else
        {
            musicAudioSource.mute = true;
            musicButtonImage.sprite = audioImageOff;
            mute = true;
        }
    }

    private IEnumerator WaitAndPlayNext()
    {
        while (true)
        {
            musicAudioSource.clip = clips[Random.Range(0, clips.Length)];
            musicAudioSource.Play();
            yield return new WaitForSeconds(musicAudioSource.clip.length);
        }
    }


}
