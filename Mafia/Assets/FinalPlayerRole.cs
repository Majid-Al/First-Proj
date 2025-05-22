using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FinalPlayerRole : MonoBehaviour
{
    public TMP_Text roleNameText;
    public Image roleImage;

    public void Setup(string roleName, Sprite roleSprite)
    {
        roleNameText.text = roleName;
        roleImage.sprite = roleSprite;
    }
}
