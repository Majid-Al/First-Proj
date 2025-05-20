using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPriiview : MonoBehaviour
{
    [SerializeField] private Text playerName;
    [SerializeField] private Image playerImage;



    public void Setup(string playerName/*Sprite playerImage*/)
    {
        this.playerName.text = playerName;
        //this.playerImage.sprite = playerImage;
    }
    public void PlayerImage()
    {
       
    }


    //Action delete

}
