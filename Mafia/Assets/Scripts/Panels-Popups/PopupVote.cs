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

    private void Start()
    {

         //   List<object> player = new List<object>();
       // foreach (object obj in the-Recived-List-of-players-with-theyr-role)
       // {
            PlayerVotingPrefab item = Instantiate(playersPrefab, playersListParent, true).GetComponent<PlayerVotingPrefab>();
            instantiatedPlayersList.Add(item);
           // item.nameText = obj.playerName;
           //item.roleText = obj.role;

        // }


    }





    public void ResetVotes()
    {
        //instantiatedPlayersList.voteText == "00";
    }


}
