using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopupVote : MonoBehaviour
{
    [SerializeField]
    GameObject playersPrefab;
    [SerializeField]
    Transform playersListParent;
    List<PlayerVotingPrefab> instantiatedPlayersList = new List<PlayerVotingPrefab>();

    //private void Start()
    //{

    //     //   List<object> player = new List<object>();
    //   // foreach (object obj in the-Recived-List-of-players-with-theyr-role)
    //   // {
    //        PlayerVotingPrefab item = Instantiate(playersPrefab, playersListParent, true).GetComponent<PlayerVotingPrefab>();
    //        instantiatedPlayersList.Add(item);
    //       // item.nameText = obj.playerName;
    //       //item.roleText = obj.role;

    //    // }


    //}

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
        //instantiatedPlayersList.voteText == "00";
    }


}
