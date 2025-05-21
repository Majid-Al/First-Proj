using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NeonFlicker : MonoBehaviour
{
    [SerializeField]
    public Image signRenderer;
    public Image signRenderer2;
    public float minAlpha = 0.2f;
    public float maxAlpha = 1f;
    public float flickerSpeed = 0.1f;
    bool flag = false;
    public float smoothFadeDuration;
    public float smoothFadeHoldDuration;

    void Start()
    {
        StartCoroutine(Flicker());
        StartCoroutine(SmoothFlicker());

    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float alpha = Random.Range(minAlpha, maxAlpha);
            Color color = signRenderer.color;
            color.a = alpha;
            signRenderer.color = color;

            yield return new WaitForSeconds(Random.Range(flickerSpeed / 2f, flickerSpeed * 2f));
        }
    }
    IEnumerator SmoothFlicker()
    {
        while (true)
        {
            yield return StartCoroutine(FadeTo(flag ? maxAlpha : minAlpha));
            flag = !flag;
            yield return new WaitForSeconds(smoothFadeHoldDuration);
        }
    }
    IEnumerator FadeTo(float targetAlpha)
    {
        float startAlpha = signRenderer2.color.a;
        float elapsed = 0f;

        while (elapsed < smoothFadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / smoothFadeDuration);
            Color color = signRenderer2.color;
            color.a = alpha;
            signRenderer2.color = color;
            yield return null;
        }
        Color finalColor = signRenderer2.color;
        finalColor.a = targetAlpha;
        signRenderer2.color = finalColor;
    }
}
