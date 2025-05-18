using TMPro;
using UnityEngine;

public class PlayerVotingScript : MonoBehaviour
{
    [SerializeField]TMP_Text nameText;
    [SerializeField]TMP_Text roleText;
    [SerializeField]TMP_Text voteText;
    int votes = 0;
    
    public void AddVote()
    {
        votes++;
        voteText.text = votes.ToString();
    }
}
