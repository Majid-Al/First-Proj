using UnityEngine;
using TMPro;
using UnityEngine.UI;
using RTLTMPro;

public class FinalPlayerRole : MonoBehaviour
{
    public RTLTextMeshPro roleNameText;
    public Image roleImage;

    public void Setup(string roleName, Sprite roleSprite)
    {
        roleNameText.text = roleName;
        roleImage.sprite = roleSprite;
    }
}
