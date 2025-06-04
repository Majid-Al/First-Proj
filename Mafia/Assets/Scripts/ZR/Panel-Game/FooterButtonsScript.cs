using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FooterButtonsScript : MonoBehaviour
{


    #region --- SoundButton

    [SerializeField] Image loadingCircle;
    public void ShowProgress()
    {
        loadingCircle.gameObject.SetActive(true);
        StartCoroutine(ChangeColorOverTime(Color.black, Color.white, 0.7f));
    }
    private IEnumerator ChangeColorOverTime(Color startColor, Color endColor, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            loadingCircle.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
            yield return null; // Wait for the next frame
        }

        // Ensure the final color is set
        loadingCircle.color = endColor;
    }
    public void HideProgress()
    {
        loadingCircle.gameObject.SetActive(false);
    }

    #endregion


    #region ---Day/Night
    bool day = false;
    [SerializeField]
    RTLTextMeshPro phase;
    [SerializeField]
    Image gamePanelImage;
    [SerializeField]
    RTLTextMeshPro dayCounter;
    int dayCount = 0;

    public void NextPhase()
    {
        if (day)
        {
            day = false;
            phase.text = "شب";
            phase.color = new Color(224f / 255f, 60f / 255f, 50f / 255f, 255f / 255f);
            gamePanelImage.color = new Color(104f / 255f, 150f / 255f, 230f / 255f);
        }
        else
        {
            day = true;
            phase.text = "روز";
            phase.color = new Color(50f / 255f, 224f / 255f, 73f / 255f, 255f / 255f);
            dayCount++;
            dayCounter.text = dayCount.ToString();
            gamePanelImage.color = new Color(255f / 255f, 217f / 255f, 148f / 255f);
        }


    }
    #endregion
}
