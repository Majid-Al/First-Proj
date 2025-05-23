using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVotingPrefab : MonoBehaviour
{
    [SerializeField] RTLTextMeshPro nameText;
    [SerializeField] RTLTextMeshPro roleText;
    [SerializeField] RTLTextMeshPro voteText;
    [SerializeField] Image avatarImage;
    int votes = 0;

    public void Setup(string playerName, string roleName, Sprite avatar)
    {
        nameText.text = playerName;
        roleText.text = roleName;
        avatarImage.sprite = avatar;
    }
    public void AddVote()
    {
        votes++;
        voteText.text = votes.ToString();
    }
    public void RemoveVote()
    {
        // votes--;
        votes = Mathf.Max(0, votes - 1);
        voteText.text = votes.ToString();
    }
}
