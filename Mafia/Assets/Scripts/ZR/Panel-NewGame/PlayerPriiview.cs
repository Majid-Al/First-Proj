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
        Debug.Log(playerName.text);
        string nameKey = "Player" + playerIndex + "_Name";
        string avatarKey = "Player" + playerIndex + "_Avatar";

        for (int i = GameManager.Instance.players.Count - 1; i >= 0; i--)
        {
            var item = GameManager.Instance.players[i];
            if (item.name == playerName.text)
            {
                PlayerPrefs.DeleteKey(nameKey);
                PlayerPrefs.DeleteKey(avatarKey);
                GameManager.Instance.players.RemoveAt(i);
            }
        }

        Destroy(gameObject);
    }

}
