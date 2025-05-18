using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Panel_NewGame : MonoBehaviour
{
    [SerializeField] private PlayerPriiview playerPreview;
    [SerializeField] private Transform content;
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private List<string> listPlayerName;
    [SerializeField] private List<Sprite> availableImages;
    private List<Sprite> unAvailableImages = new List<Sprite>();

    private void Start()
    {
        unAvailableImages=new List<Sprite>(availableImages);
    }
    public void AddPlayer()
    {
       string playerName= inputName.text;

        if(string.IsNullOrEmpty(playerName))
            return;
        
        int index = Random.Range(0,unAvailableImages.Count);
        Sprite selectedSprite=unAvailableImages[index];
        unAvailableImages.RemoveAt(index);

       var player= Instantiate(playerPreview , content);
       player.Setup(playerName , selectedSprite);

        listPlayerName.Add(playerName);
        inputName.text = "";
    }

    public void NextButton()
    {

        if (listPlayerName.Count < 5)
        {
            Debug.Log("Player Count HaveTo be More than 5");
            Debug.Log($"{listPlayerName.Count} + listPlayer");
        }
        else
        {
            Debug.Log("It  is Ok");
            Debug.Log($"{listPlayerName.Count} + listPlayer");
        }
    }
}
