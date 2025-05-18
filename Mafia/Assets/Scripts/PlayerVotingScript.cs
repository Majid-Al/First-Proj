using TMPro;
using UnityEngine;

public class PlayerVotingPrefab : MonoBehaviour
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
    public void RemoveVote()
    {
        votes--;
        voteText.text = votes.ToString();
    }
}
