using UnityEngine;

public class PanelGame : MonoBehaviour
{

    public void OpenPopup(GameObject popUp)
    {
        Instantiate(popUp);
    }

}
