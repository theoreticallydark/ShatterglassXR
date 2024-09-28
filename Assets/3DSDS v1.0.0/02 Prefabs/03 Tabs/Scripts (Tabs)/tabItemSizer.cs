using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class tabItemSizer : MonoBehaviour
{
    public GameObject cube; // Assign the cube GameObject in the inspector
    float tabItemWidth;

    void Update()
    {
        TabsManager parentScript = transform.parent.GetComponent<TabsManager>();
        tabItemWidth = parentScript.largestTabItem();
        //Debug.Log(tabItemWidth);

        // Get the RectTransform of the first child
        RectTransform childRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
        RectTransform parentRectTransform = GetComponent<RectTransform>(); //not the parent actually, but the gameObject itself

        if (childRectTransform != null && parentRectTransform != null && cube != null)
        {
            // Update the parent's size to match the first child's size
            parentRectTransform.sizeDelta = new Vector2(tabItemWidth + 32f + 2f + 16f, childRectTransform.sizeDelta.y);

            // Get the size of the UI button (now updated to the first child's size)
            Vector2 size = new Vector2(tabItemWidth, parentRectTransform.sizeDelta.y);

            // Update the cube's scale to match the button's size
            cube.transform.localScale = new Vector3(size.x + 32f + 2f + 16f, size.y, cube.transform.localScale.z);
        }
    }
}

