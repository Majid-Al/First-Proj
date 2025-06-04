using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupVote : MonoBehaviour
{

    [SerializeField]
    GameObject playersPrefab;

    [SerializeField]
    Transform playersListParent;
    List<PlayerVotingPrefab> instantiatedPlayersList = new List<PlayerVotingPrefab>();


    private void Start()
    {
        var players = GameManager.Instance.players;
        var roles = GameManager.Instance.selectedRoles;

        for (int i = 0; i < players.Count; i++)
        {
            var itemGO = Instantiate(playersPrefab, playersListParent);
            var playerItem = itemGO.GetComponent<PlayerVotingPrefab>();

            playerItem.Setup(players[i].name, roles[i].roleName, players[i].avatar);
            instantiatedPlayersList.Add(playerItem);
        }
    }

    public void ResetVotes()
    {
        foreach (var playerItem in instantiatedPlayersList)
        {
            playerItem.ResetVote();
        }
    }
}
