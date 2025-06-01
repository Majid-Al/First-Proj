using RTLTMPro;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

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


    //Day/night cycle
    bool day = false;
    [SerializeField]
    RTLTextMeshPro phase;
    [SerializeField]
    RTLTextMeshPro dayCounter;
    int dayCount = 0;

    public void NextPhase()
    {
        if (day)
        {
            day = false;
            phase.text = "شب";
            phase.color = new Color(224f / 255f, 60f / 255f, 50f / 255f, 255f / 255f);
        }
        else
        {
            day = true;
            phase.text = "روز";
            phase.color = new Color(50f / 255f, 224f / 255f, 73f / 255f, 255f / 255f);
            dayCount++;
            dayCounter.text = dayCount.ToString();
        }

    }



}
