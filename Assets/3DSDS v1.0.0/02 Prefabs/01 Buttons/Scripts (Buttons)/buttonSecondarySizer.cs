using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class buttonSecondarySizer : MonoBehaviour
{
    public RectTransform base0;
    public RectTransform skin;


    void Update()
    {

        skin = transform.GetChild(1).GetComponent<RectTransform>();
        base0 = transform.GetChild(0).GetComponent<RectTransform>();

        if (base0 != null && skin != null)
        {
            // Update the parent's size to match the first child's size
            //skin.sizeDelta = new Vector2(label.sizeDelta.x, label.sizeDelta.y);
            //skin.sizeDelta = new Vector2(label.sizeDelta.x, label.sizeDelta.y);
            base0.sizeDelta = new Vector2(skin.sizeDelta.x, skin.sizeDelta.y);
            gameObject.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(skin.sizeDelta.x, skin.sizeDelta.y);
        }
    }
}

