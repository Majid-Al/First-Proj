using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleItemUI : MonoBehaviour
{
    public TMP_Text roleNameText;
    public Image roleImageText;
    public TMP_Text countText;
    public Button plusButton;
    public Button minusButton;

    private RoleItem roleData;
    private Panel_Roles panelRoles;

    public void Setup(RoleItem data, Panel_Roles panel)
    {
        roleData = data;
        panelRoles = panel;
        roleNameText.text = data.roleName;
        roleImageText.sprite = roleData.roleImage;

        plusButton.onClick.RemoveAllListeners();
        minusButton.onClick.RemoveAllListeners();

        plusButton.onClick.AddListener(() =>
        {
            if (panelRoles.CanAddMoreRoles())
            {
                if (roleData.isMultipleAllowed || roleData.count == 0)
                {

                    roleData.count++;
                    UpdateCount();
                    panelRoles.OnRoleCountChanged();

                }
            }
        });

        minusButton.onClick.AddListener(() =>
        {
            if (roleData.count == 1)
            {
                roleData.count--;
                UpdateCount(); 
                panelRoles.OnRoleCountChanged();

            }
        });


        UpdateCount();
    }

    private void UpdateCount()
    {
        countText.text = roleData.count.ToString();

        countText.ForceMeshUpdate();  

    }
}
