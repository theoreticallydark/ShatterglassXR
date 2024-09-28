using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class buttonPrimarySizer : MonoBehaviour
{
    public GameObject cube; // Assign the cube GameObject in the inspector

    void Update()
    {
        // Get the RectTransform of the first child
        RectTransform childRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
        RectTransform parentRectTransform = GetComponent<RectTransform>();

        if (childRectTransform != null && parentRectTransform != null && cube != null)
        {
            // Update the parent's size to match the first child's size
            parentRectTransform.sizeDelta = new Vector2(childRectTransform.sizeDelta.x + 16f, childRectTransform.sizeDelta.y);

            // Get the size of the UI button (now updated to the first child's size)
            Vector2 size = parentRectTransform.sizeDelta;

            // Update the cube's scale to match the button's size
            cube.transform.localScale = new Vector3(size.x, size.y, cube.transform.localScale.z);
        }
    }
}

