using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using RTLTMPro;

public class PopupTimer : MonoBehaviour
{

    [SerializeField]
    RTLTextMeshPro text;
    [SerializeField]
    TMP_InputField inputField;

    [SerializeField]
    AudioSource textAudioSource;
    bool inProgress= false;
    // gets called from buttons in the panel
    public void StartCustomCountDown(int time)
    {
        if (time == 0 && inputField != null && int.TryParse(inputField.text, out int result) && !inProgress)
        {
            inProgress = true;
            int countdownTime = result;
            StartCoroutine(CountdownCoroutine(countdownTime));
        }
        else if (time > 0 && !inProgress)
        {
            inProgress = true;
            StartCoroutine(CountdownCoroutine(time));
        }

    }



    private IEnumerator CountdownCoroutine(int time)
    {
        while (time > 0)
        {
            System.TimeSpan newTime = System.TimeSpan.FromSeconds(time);
            text.text = newTime.ToString(@"mm\:ss");
            yield return new WaitForSeconds(1);
            time--;
        }
        text.text = "00";
        inProgress = false;
        textAudioSource.Play();

    }
}
