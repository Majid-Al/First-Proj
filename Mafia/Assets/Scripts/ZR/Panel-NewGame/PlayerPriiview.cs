using NUnit.Framework;
using RTLTMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPriiview : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro playerName;
    [SerializeField] private Image playerImage;



    public void Setup(string playerName/*Sprite playerImage*/)
    {
        this.playerName.text = playerName;

        //this.playerImage.sprite = playerImage;
    }
    public void PlayerImage()
    {
       
    }
    public void Close()
    {
        Debug.Log(GameManager.Instance.playerNames.Count);
        Debug.Log(playerName.text);
        GameManager.Instance.playerNames.Remove(playerName.text);
        Debug.Log(GameManager.Instance.playerNames.Count);
        Destroy(gameObject);
    }

    //Action delete

}
