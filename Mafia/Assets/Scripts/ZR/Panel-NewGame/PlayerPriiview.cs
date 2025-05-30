using NUnit.Framework;
using RTLTMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPriiview : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro playerName;
    [SerializeField] private Image playerImage;
    private int playerIndex;
    public void Setup(string playerName,Sprite playerImage,int PlayerCount)
    {
        this.playerName.text = playerName;
        playerIndex = PlayerCount;
        this.playerImage.sprite = playerImage;
    }
    public void Close()
    {
        Debug.Log(GameManager.Instance.playerNames.Count);
        Debug.Log(playerName.text);
        GameManager.Instance.playerNames.Remove(playerName.text);
        Debug.Log(GameManager.Instance.playerNames.Count);


        string nameKey = "Player" + playerIndex + "_Name";
        string avatarKey = "Player" + playerIndex + "_Avatar";

        PlayerPrefs.DeleteKey(nameKey);
        PlayerPrefs.DeleteKey(avatarKey);
        Destroy(gameObject);
    }

}
