using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPriiview : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro playerName;
    private string playerStringName;
    [SerializeField] private Image playerImage;
    private int playerIndex;
    public void Setup(string playerName,Sprite playerImage,int PlayerCount)
    {
        this.playerName.text = playerName;
        playerStringName = playerName;
        playerIndex = PlayerCount;
        this.playerImage.sprite = playerImage;
    }
    public void Close()
    {
        Debug.Log(playerName.text);
        string nameKey = "Player" + playerIndex + "_Name";
        string avatarKey = "Player" + playerIndex + "_Avatar";
        int playerCount = PlayerPrefs.GetInt("SavedPlayerCount", 0);
        for (int i = GameManager.Instance.players.Count - 1; i >= 0; i--)
        {
            var item = GameManager.Instance.players[i];
                Debug.Log(item.name);
            if (item.name == playerStringName)
            {
                Debug.Log("majid the player got deleted");
                PlayerPrefs.DeleteKey(nameKey);
                PlayerPrefs.DeleteKey(avatarKey);
                GameManager.Instance.players.RemoveAt(i);
                PlayerPrefs.SetInt("SavedPlayerCount", playerCount-1);
            }
        }
        Destroy(gameObject);
    }

}
