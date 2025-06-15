using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Roles : MonoBehaviour
{
    ShowRewardAdScript showRewardAdScript;

    [SerializeField] private List<RoleItem> allRoles;
    [SerializeField] private Transform mafiaContainer;
    [SerializeField] private Transform cityContainer;
    [SerializeField] private Transform independentContainer;
    [SerializeField] private RoleItemUI roleItemPrefab;
    [SerializeField] private GameObject PannelRevealRole, popupWarning, popupAdNotification;
    [SerializeField] private Button addRoleButtonPrefab;
    [SerializeField] private GameObject popupAddRole;
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TMP_InputField roleNameInputField; 
    [SerializeField] private Sprite questionMan, mafiaDefaultSprite, cityDefaultSprite, defaultSprite;

    private RoleCategory selectedCategoryForAdding;
    private int totalPlayers;

    public async void SetUp()
    {
        popupAdNotification.SetActive(true);
        totalPlayers = GameManager.Instance.players.Count;
        CreateUIItems();
        await OnRoleCountChanged();
        this.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        confirmButton.onClick.AddListener(OnConfirmAddRole);
        
    }
    private void OnConfirmAddRole()
    {
        string newRoleName = roleNameInputField.text.Trim();
        if (string.IsNullOrEmpty(newRoleName))
        {
            Debug.LogWarning("نام نقش نمی‌تواند خالی باشد!");
            return;
        }
        switch (selectedCategoryForAdding)
        {
            case RoleCategory.Mafia:
                questionMan = mafiaDefaultSprite;
                break;
            case RoleCategory.City:
                questionMan = cityDefaultSprite;
                break;
            default:
                questionMan = defaultSprite; 
                break;
        }
        RoleItem newRole = new RoleItem
        {
            roleName = newRoleName,
            category = selectedCategoryForAdding,
            roleImage = questionMan, 
            count = 0,
            isMultipleAllowed = true
        };

        allRoles.Add(newRole);

        Transform parent = GetParentContainer(selectedCategoryForAdding);
        Debug.Log("Parent: " + parent.name);
        foreach (Transform child in parent)
        {
            Debug.Log("Child: " + child.name);
        }

        Button addButton = parent.GetComponentsInChildren<Button>()
                                 .FirstOrDefault(btn => btn.name == "AddBtn(Clone)");
       if (addButton != null)
        {
            int addButtonIndex = addButton.transform.GetSiblingIndex();
            var ui = Instantiate(roleItemPrefab, parent);
            ui.Setup(newRole, this);
            ui.transform.SetSiblingIndex(addButtonIndex);
        }
        else
        {
            Debug.LogWarning("دکمه AddBtn پیدا نشد!");
        }

        popupAddRole.SetActive(false);
    }

    private void CreateUIItems()
    {
        foreach (var role in allRoles)
        {
            Transform parent = GetParentContainer(role.category);
            var ui = Instantiate(roleItemPrefab, parent);
            ui.Setup(role, this);
        }

        AddAddButton(mafiaContainer, RoleCategory.Mafia);
        AddAddButton(cityContainer, RoleCategory.City);
        AddAddButton(independentContainer, RoleCategory.Independent);
    }

    private void AddAddButton(Transform parent, RoleCategory category)
    {
        var addButton = Instantiate(addRoleButtonPrefab, parent);
        showRewardAdScript = addButton.GetComponent<ShowRewardAdScript>();
        addButton.onClick.AddListener(() => OnAddButtonClicked(category));
        addButton.interactable = false;
    }
    private void OnAddButtonClicked(RoleCategory category)
    {
        showRewardAdScript.ShowAd();
        selectedCategoryForAdding = category;

        //bool adShown = adiveryAdHandler.ShowRewardAd();
        //if (adShown)
        //{
        //    roleNameInputField.text = "";
        //    popupAddRole.SetActive(true);
        //}
        //else
        //{
        //    //  there is a problem with adding the new roll please try again later - message
        //    Debug.Log("there is a in loading the ad");
        //}
    }


    public void adShownSuccessfully()
    {
        Debug.Log("Parent active in hierarchy: " + popupAddRole.transform.parent.gameObject.activeInHierarchy);

        Debug.Log("majid ad shown success and this func got called");
        roleNameInputField.text = "";
        Debug.Log("1");

        //StartCoroutine(DebugPopupWatcher());
        popupAddRole.SetActive(true);
        Debug.Log("2");

    }

    IEnumerator DebugPopupWatcher()
    {
        popupAddRole.SetActive(true);
        yield return new WaitForSeconds(1f);
        Debug.Log("Still active after 1 second: " + popupAddRole.activeSelf);
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

    public Task OnRoleCountChanged()
    {
        int totalSelected = GetCurrentTotalSelected();
        nextButton.interactable = (totalSelected == totalPlayers);
        Debug.Log($"‌Choose: {totalSelected}/{totalPlayers}");
        return Task.CompletedTask;
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
    public string roleDescription;
    public Sprite roleImage;
    public RoleCategory category;
    public int count=0;
    public bool isMultipleAllowed;

    public string actionText;
    public Sprite actionIcon;
}

