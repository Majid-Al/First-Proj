using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Panel_Game : MonoBehaviour
{
    public static Panel_Game Instance;
    void Awake() => Instance = this;


    [Header("Parents for scroll views")]
    public Transform playerInfoContent; 
    public Transform playerRoleContent; 

    [Header("Prefabs")]
    public GameObject playerInfoPrefab; 
    public GameObject playerRolePrefab;
     
    public GameObject scrollViewA;
    public GameObject scrollViewB; 

    public void OnPointerDown()
    {
        scrollViewA.SetActive(false);
        scrollViewB.SetActive(true);
    }

    public void OnPointerUp()
    {
        scrollViewA.SetActive(true);
        scrollViewB.SetActive(false);
    }

    void Start()
    {
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
            var infoUI = infoGO.GetComponent<FinalPlayerInfo>();
            infoUI.Setup(players[i].name, players[i].avatar);

            infoGO.GetComponent<Button>().onClick.AddListener(() => infoUI.OnClick());

            // Instantiate Player Role
            var roleGO = Instantiate(playerRolePrefab, playerRoleContent);
            var roleUI = roleGO.GetComponent<FinalPlayerRole>(); 
            roleUI.Setup(roles[i].roleName, roles[i].roleImage);

        }
    }

    public Transform mafiaActionsParent;
    public Transform cityActionsParent;
    public RoleAction actionItemPrefab;



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

                        // case RoleCategory.Independent:
                        //     targetParent = independentActionsParent;
                        //     break;
                }

                if (targetParent != null)
                {
                    var go = Instantiate(actionItemPrefab, targetParent);
                    var actionUI = go.GetComponent<RoleAction>();

                    if (actionUI != null)
                    {
                        actionUI.Setup(role.actionText, role.actionIcon);
                    }
                    else
                    {
                        Debug.LogError("RoleAction component not found on prefab!");
                    }
                }
            }
        }
    }

    private FinalPlayerInfo selectedPlayer;

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
    [SerializeField] GameObject popupVotePanel;

    public void OnClick_VoteButton()
    {
        popupVotePanel.SetActive(true);

    }

}
