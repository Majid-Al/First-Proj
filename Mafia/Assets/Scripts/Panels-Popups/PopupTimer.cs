using UnityEngine;
using System.Collections;
using RTLTMPro;

public class PopupTimer : MonoBehaviour
{

    [SerializeField]
    RTLTextMeshPro text;

    [SerializeField]
    AudioSource textAudioSource;

    // gets called from buttons in the panel
    public void StartCustomCountDown(int time)
    {
        StopAllCoroutines();
        StartCoroutine(CountdownCoroutine(time));
    }


    private IEnumerator CountdownCoroutine(int time)
    {
        while (time > 0 )
        {
            System.TimeSpan newTime = System.TimeSpan.FromSeconds(time);
            text.text = newTime.ToString(@"mm\:ss");
            yield return new WaitForSeconds(1);
            time--;
        }
        text.text = "00:00";
        textAudioSource.Play();

    }
}
