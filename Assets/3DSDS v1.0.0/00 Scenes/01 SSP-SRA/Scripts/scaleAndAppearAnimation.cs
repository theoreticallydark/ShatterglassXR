using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scaleAndAppearAnimation : MonoBehaviour
{

    [SerializeField] Button switchToState2;
    [SerializeField] Button switchToState1;

    void Start()
    {
        switchToState2.onClick.AddListener(() => StartCoroutine(ScaleAndSwitch(0, 1)));
        switchToState1.onClick.AddListener(() => StartCoroutine(ScaleAndSwitch(1, 0)));
    }

    IEnumerator ScaleAndSwitch(int deactivateChildIndex, int activateChildIndex)
    {
        yield return StartCoroutine(Scale(1, 0, 0.24f));
        transform.GetChild(deactivateChildIndex).gameObject.SetActive(false);
        transform.GetChild(activateChildIndex).gameObject.SetActive(true);
        yield return StartCoroutine(Scale(0, 1, 0.24f));
    }

    IEnumerator Scale(float startScale, float endScale, float duration)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            float scale = Mathf.Lerp(startScale, endScale, elapsed / duration);
            transform.localScale = new Vector3(scale, scale, scale);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector3(endScale, endScale, endScale);
    }
}
