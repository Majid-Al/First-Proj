using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleAction : MonoBehaviour
{
    public RTLTextMeshPro actionName;
    public Image actionImage;
    private Sprite actionIcon;
    public  void Setup(string actionName , Sprite actionImage)
    {
        this.actionImage.sprite = actionImage;
        actionIcon = actionImage;
        this.actionName.text= actionName;
    }

    public void OnClick()
    {
        Panel_Game.Instance.OnActionClicked(actionIcon);
    }

}
