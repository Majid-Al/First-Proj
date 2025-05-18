using RTLTMPro;
using TMPro;
using UnityEngine;

public class PlayerVotingPrefab : MonoBehaviour
{
    [SerializeField] RTLTextMeshPro nameText;
    [SerializeField] RTLTextMeshPro roleText;
    [SerializeField] RTLTextMeshPro voteText;
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
