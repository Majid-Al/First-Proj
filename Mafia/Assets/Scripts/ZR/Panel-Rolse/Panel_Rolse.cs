using RTLTMPro;
using TMPro;
using UnityEngine;

public class Panel_Rolse : MonoBehaviour
{
    [SerializeField] private RTLTextMeshPro mafiaCountText;
    [SerializeField] private RTLTextMeshPro cityCountText;
    [SerializeField] private RTLTextMeshPro independentCountText;
    private int totalPlayers;

    private int mafiaCount = 0;
    private int cityCount = 0;
    private int independentCount = 0;

    private void Start()
    {
        int count = GameManager.Instance.playerNames.Count;
        UpdateUI();
    }
    public void IncreaseMafia()
    {
        if (mafiaCount + cityCount + independentCount < totalPlayers)
            mafiaCount++;
        UpdateUI();
    }
    public void IncreaseCity()
    {
        if (mafiaCount + cityCount + independentCount < totalPlayers)
            cityCount++;
        UpdateUI();
    }

    public void IncreaseIndependent()
    {
        if (mafiaCount + cityCount + independentCount < totalPlayers)
            independentCount++;
        UpdateUI();
    }
    private void UpdateUI()
    {
        mafiaCountText.text = mafiaCount.ToString();
        cityCountText.text = cityCount.ToString();
        independentCountText.text = independentCount.ToString();
    }



}
