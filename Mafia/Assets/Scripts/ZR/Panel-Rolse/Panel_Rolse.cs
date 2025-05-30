using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Roles : MonoBehaviour
{
    [SerializeField] private List<RoleItem> allRoles;
    [SerializeField] private Transform mafiaContainer;
    [SerializeField] private Transform cityContainer;
    [SerializeField] private Transform independentContainer;
    [SerializeField] private RoleItemUI roleItemPrefab;
    [SerializeField] private GameObject PannelRevealRole;

    [SerializeField] private Button nextButton;

    private int totalPlayers;

    private void Start()
    {
        totalPlayers = GameManager.Instance.players.Count;
        CreateUIItems();
        OnRoleCountChanged();
    }

    private void CreateUIItems()
    {
        foreach (var role in allRoles)
        {
            Transform parent = GetParentContainer(role.category);
            var ui = Instantiate(roleItemPrefab, parent);
            ui.Setup(role, this);
        }
    }

    private Transform GetParentContainer(RoleCategory category)
    {
        switch (category)
        {
            case RoleCategory.Mafia: return mafiaContainer;
            case RoleCategory.City: return cityContainer;
            case RoleCategory.Independent: return independentContainer;
            default: return null;
        }
    }

    public bool CanAddMoreRoles()
    {
        return GetCurrentTotalSelected() < totalPlayers;
    }

    public void OnRoleCountChanged()
    {
        int totalSelected = GetCurrentTotalSelected();
        nextButton.interactable = (totalSelected == totalPlayers);
        Debug.Log($"‌Choose: {totalSelected}/{totalPlayers}");
    }

    private int GetCurrentTotalSelected()
    {
        int total = 0;
        foreach (var role in allRoles)
        {
            total += role.count;
        }
        return total;
    }

    public List<RoleItem> GetSelectedRoles()
    {
        return allRoles.FindAll(role => role.count > 0);
    }

    public void OnNextButtonClicked()
    {
        if (GetCurrentTotalSelected() == totalPlayers)
        {
            Debug.Log("SUCCESS");
            SaveSelectedRoles();
        }
        else
        {
            Debug.LogWarning("Not Ok !");
        }
    }

    public void SaveSelectedRoles()
    {
        List<RoleItem> finalRoles = new List<RoleItem>();

        foreach (var role in allRoles)
        {
            for (int i = 0; i < role.count; i++)
            {
                finalRoles.Add(role); 
            }
        }

        finalRoles = finalRoles.OrderBy(x => Random.value).ToList();

        GameManager.Instance.selectedRoles = finalRoles;
        PannelRevealRole.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
public enum RoleCategory
{
    Mafia,
    City,
    Independent
}

[System.Serializable]
public class RoleItem
{
    public string roleName;
    public Sprite roleImage;
    public RoleCategory category;
    public int count=0;
    public bool isMultipleAllowed;

    public string actionText;
    public Sprite actionIcon;
}

