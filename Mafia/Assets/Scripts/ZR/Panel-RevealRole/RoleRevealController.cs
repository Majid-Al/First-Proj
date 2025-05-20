using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class RoleRevealController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject beforeRevealPanel;
    public GameObject afterRevealPanel;

    [Header("Before Reveal UI")]
    public TMP_Text playerNameText;
    public Button revealButton;

    [Header("After Reveal UI")]
    public TMP_Text revealedRoleText;
    public Image revealedRoleImage;
    public Button nextPlayerButton;

    private List<string> playerNames;
    private List<RoleItem> selectedRoles;
    private int currentIndex = 0;

    void Start()
    {
        playerNames = GameManager.Instance.playerNames;
        selectedRoles = GameManager.Instance.selectedRoles;

        Shuffle(selectedRoles); 
        ShowBeforePanel();
    }

    void ShowBeforePanel()
    {
        beforeRevealPanel.SetActive(true);
        afterRevealPanel.SetActive(false);

        playerNameText.text = playerNames[currentIndex];

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

        nextPlayerButton.onClick.RemoveAllListeners();
        nextPlayerButton.onClick.AddListener(() =>
        {
            currentIndex++;
            if (currentIndex < playerNames.Count)
                ShowBeforePanel();
            else
                Debug.Log("All Role Showed!");
        });
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
