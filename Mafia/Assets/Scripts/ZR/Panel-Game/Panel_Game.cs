using AdiveryUnity;
using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Panel_Game : MonoBehaviour
{
    public static Panel_Game Instance;
    [SerializeField] private AdiveryAdHandler adiveryAdHandler;
    void Awake() => Instance = this;

    [Header("Parents for scroll view")]
    public Transform playerInfoContent; 

    [Header("Prefabs")]
    public FinalPlayerInfo playerInfoPrefab; 
    public FinalPlayerRole playerRolePrefab;
    public Transform mafiaActionsParent;
    public Transform cityActionsParent;
    public RoleAction actionItemPrefab;
    private FinalPlayerInfo selectedPlayer;
    [SerializeField] GameObject popupVotePanel;

    void Start()
    {
        StartCoroutine(ShowTimeBaseAd());
        CreateFinalLists();
        ShowAllActions();
    }
    void CreateFinalLists()
    {
        var players = GameManager.Instance.players;
        var roles = GameManager.Instance.selectedRoles;

        for (int i = 0; i < players.Count; i++)
        {
            // Instantiate Player Info
            var infoGO = Instantiate(playerInfoPrefab, playerInfoContent);
            infoGO.Setup(players[i].name, players[i].avatar);
            infoGO.GetComponent<Button>().onClick.AddListener(() => infoGO.OnClick());

            // Instantiate Player Role
            var roleGO = Instantiate(playerRolePrefab, infoGO.roleHolder);
            roleGO.Setup(roles[i].roleName, roles[i].roleImage);

        }
    }
    void ShowAllActions()
    {
        List<RoleItem> roles = GameManager.Instance.selectedRoles;

        foreach (var role in roles)
        {
            if (role.actionIcon != null && !string.IsNullOrEmpty(role.actionText))
            {
                Transform targetParent = null;

                switch (role.category)
                {
                    case RoleCategory.Mafia:
                        targetParent = mafiaActionsParent;
                        break;

                    case RoleCategory.City:
                        targetParent = cityActionsParent;
                        break;
                }

                if (targetParent != null)
                {
                    var go = Instantiate(actionItemPrefab, targetParent);
                    var actionUI = go.GetComponent<RoleAction>();

                    if (actionUI != null)
                    {
                        actionUI.Setup(role.roleName, role.actionIcon);
                    }
                    else
                    {
                        Debug.LogError("RoleAction component not found on prefab!");
                    }
                }
            }
        }
    }
    public void OnPlayerClicked(FinalPlayerInfo player)
    {
        if (selectedPlayer != null)
            selectedPlayer.SetSelected(false); 

        selectedPlayer = player;
        selectedPlayer.SetSelected(true);
    }
    public void OnActionClicked(Sprite actionIcon)
    {
        if (selectedPlayer != null)
        {
            selectedPlayer.AddActionIcon(actionIcon);
        }
    }
    public void OnClick_VoteButton()
    {
        popupVotePanel.SetActive(true);
    }
    public void ResetAllActionIcons()
    {
        foreach (Transform child in playerInfoContent)
        {
            FinalPlayerInfo info = child.GetComponent<FinalPlayerInfo>();
            if (info != null)
            {
                info.ClearActionIcons();
            }
        }
    }
    public void OnShowRoleButtonPointerDown()
    {
        foreach (Transform child in playerInfoContent)
        {
            FinalPlayerInfo info = child.GetComponent<FinalPlayerInfo>();
            if (info != null)
            {
                info.ShowRoleHolder();
            }
        }
    }
    public void OnShowRoleButtonPointerUp()
    {
        foreach (Transform child in playerInfoContent)
        {
            FinalPlayerInfo info = child.GetComponent<FinalPlayerInfo>();
            if (info != null)
            {
                info.ShowPlayerHolder();
            }
        }
    }

    #region -- timebase Ad
    [SerializeField]
    RTLTextMeshPro adTimerText;
    private IEnumerator ShowTimeBaseAd()
    {
        while (true)
        {
            yield return StartCoroutine(CountdownCoroutine(300));
            adiveryAdHandler.ShowInterstitialAd();
        }
    }

    private IEnumerator CountdownCoroutine(int time)
    {
        while (time > 0)
        {
            System.TimeSpan newTime = System.TimeSpan.FromSeconds(time);
            adTimerText.text = newTime.ToString(@"ss\:mm");
            yield return new WaitForSeconds(1);
            time--;
        }
        adTimerText.text = "00:00";
    }
    #endregion
}
