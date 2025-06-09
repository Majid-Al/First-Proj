using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ContentSize : MonoBehaviour
{
    [SerializeField] private ContentSizeFitter contentSizeFitter;

    IEnumerator Start()
    {
        contentSizeFitter.enabled = false;
        yield return null; 
        contentSizeFitter.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
