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

    [SerializeField] private List<Sprite> availableImages;
    private List<Sprite> unAvailableImages = new List<Sprite>();

    [SerializeField] private Button nextButton;

    private void Start()
    {
        unAvailableImages=new List<Sprite>(availableImages);
   }
    public void AddPlayer()
    {
       string playerName= inputName.text;

        if(string.IsNullOrEmpty(playerName))
            return;
        
    //    int index = Random.Range(0,unAvailableImages.Count);
    //    Sprite selectedSprite=unAvailableImages[index];
     //   unAvailableImages.RemoveAt(index);

       var player= Instantiate(playerPreview , content);
       player.Setup(playerName  /*selectedSprite*/);

        GameManager.Instance.playerNames.Add(playerName);
        inputName.text = "";
    }
    public void RemoveList(string name)
    {
        listPlayerName.Remove(name);
    }
    private void Update()
    {
        int Count = GameManager.Instance.playerNames.Count;
        bool Next = Count > 5;
        nextButton.interactable = (Next);

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
            //GameManager.Instance.playerNames = new List<string>(listPlayerName);
            Debug.Log("It  is Ok");
        }
    }
}
