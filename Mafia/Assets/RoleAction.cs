using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleAction : MonoBehaviour
{
    public RTLTextMeshPro actionName;
    public Image actionImage;

    public  void Setup(string actionName , Sprite actionImage)
    {
        this.actionImage.sprite = actionImage;
        this.actionName.text= actionName;
    }
}
