using RTLTMPro;
using TMPro;
using UnityEngine;

public class PopupNote : MonoBehaviour
{

    [SerializeField] private TMP_InputField inputField;         // User types here
    [SerializeField] private RTLTextMeshPro displayText;        // Displayed nicely

    private void OnInputChanged(string text)
    {
        displayText.text = text;
    }
    void Start()
    {
        inputField.onValueChanged.AddListener(OnInputChanged);
    }
}
