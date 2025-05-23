
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using RTLTMPro;

public class FinalPlayerInfo : MonoBehaviour
{
    public RTLTextMeshPro playerNameText;
    public Image playerAvatarImage;

    public GameObject selectionHighlight;
    public Transform actionIconHolder;

    private string playerName;

    public void Setup(string name, Sprite avatar)
    {
        playerName = name;
        playerNameText.text = name;
        playerAvatarImage.sprite = avatar;
        SetSelected(false);
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetSelected(bool isSelected)
    {
        if (selectionHighlight != null)
            selectionHighlight.SetActive(isSelected);
    }

    public void AddActionIcon(Sprite icon)
    {
        //GameObject newIcon = new GameObject("ActionIcon", typeof(Image));
        GameObject newIcon = new GameObject("ActionIcon_" + actionIconHolder.childCount, typeof(Image));
        newIcon.transform.SetParent(actionIconHolder, false);
        Image img = newIcon.GetComponent<Image>();
        img.sprite = icon;
        img.rectTransform.sizeDelta = new Vector2(80, 80);
    }

    public void ClearActionIcons()
    {
        foreach (Transform child in actionIconHolder)
            Destroy(child.gameObject);
    }

    public void OnClick()
    {
        Panel_Game.Instance.OnPlayerClicked(this);
    }
}

