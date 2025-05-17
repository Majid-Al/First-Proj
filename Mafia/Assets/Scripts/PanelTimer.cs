using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelTimer : MonoBehaviour
{

    [SerializeField]
    TMP_Text text;
    [SerializeField]
    TMP_InputField inputField;

    [SerializeField]
    AudioSource textAudioSource;

    public void StartCustomCountDown(int time)
    {
        
        if (time == 0 && inputField != null && int.TryParse(inputField.text, out int result))
        {
           int countdownTime = result;
           StartCoroutine(CountdownCoroutine(countdownTime));
        }else if (time > 0)
        {
            StartCoroutine(CountdownCoroutine(time));
        }

    }


    private IEnumerator CountdownCoroutine(int time)
    {
        while (time > 0)
        {
            text.text = time.ToString();
            yield return new WaitForSeconds(1);
            time--;
        }
        text.text = "00";

        textAudioSource.Play();

    }
}
