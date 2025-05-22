using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalPlayerInfo : MonoBehaviour
{
    public TMP_Text playerNameText;
    public Image playerAvatarImage;

    public void Setup(string name, Sprite avatar)
    {
        playerNameText.text = name;
        playerAvatarImage.sprite = avatar;
    }
}
