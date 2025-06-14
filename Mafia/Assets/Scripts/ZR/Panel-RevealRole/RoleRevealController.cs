using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using RTLTMPro;

public class RoleRevealController : MonoBehaviour
{

    [Header("Dependencies")]


    [Header("UI Panels")]
    public GameObject beforeRevealPanel;
    public GameObject afterRevealPanel;

    [Header("Before Reveal UI")]
    public RTLTextMeshPro playerNameText;
    public Image playerAvatar;
    public Button revealButton;

    [Header("After Reveal UI")]
    public RTLTextMeshPro revealedRoleText;
    public Image revealedRoleImage;
    public Button nextPlayerButton;
    public RTLTextMeshPro description;

    private List<PlayerData> players;
    private List<RoleItem> selectedRoles;
    private int currentIndex = 0;

    public GameObject panelGame,popupGoToAd;
    void Start()
    {
        players = GameManager.Instance.players;
        selectedRoles = GameManager.Instance.selectedRoles;

        Shuffle(selectedRoles); 
        ShowBeforePanel();
    }

    void ShowBeforePanel()
    {
        beforeRevealPanel.SetActive(true);
        afterRevealPanel.SetActive(false);

        playerNameText.text = players[currentIndex].name;
        Debug.Log(playerNameText.text);
        Debug.Log(players[currentIndex].name);
        playerAvatar.sprite = players[currentIndex].avatar; 

        revealButton.onClick.RemoveAllListeners();
        revealButton.onClick.AddListener(() =>
        {
            ShowAfterPanel();
        });
    }
 

    void ShowAfterPanel()
    {
        beforeRevealPanel.SetActive(false);
        afterRevealPanel.SetActive(true);

        var role = selectedRoles[currentIndex];
        revealedRoleText.text = role.roleName;
        revealedRoleImage.sprite = role.roleImage;
        description.text = role.roleDescription;

        nextPlayerButton.onClick.RemoveAllListeners();
        nextPlayerButton.onClick.AddListener(() =>
        {
            currentIndex++;
            if (currentIndex < players.Count)
                ShowBeforePanel();
            else
            {
                Debug.Log("All Role Showed!");
                popupGoToAd.SetActive(true);
            }
        });
    }

    public void GoToGame()
    {
        panelGame.SetActive(true);
       // adiveryAdHandler.ShowInterstitialAd();
        this.gameObject.SetActive(false);

    }




    void Shuffle(List<RoleItem> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            RoleItem temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
