using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TabsManager : MonoBehaviour
{

    float largestTabItemWidth = 0f;
    List<float> widthOfTabItems;
    public GameObject tabContent;

    [SerializeField, Range(2, 6)] private int numberOfTabs; // Number of tabs
    [SerializeField] private GameObject tabPrefab; // Reference to the Tab Prefab

    private void Start()
    {
        UpdateTabs();
    }

    private void Update()
    {
        UpdateTabs();
    }

    private void UpdateTabs()
    {
        // Adjust the number of tab items to match the specified number of tabs
        while (transform.childCount < numberOfTabs)
        {
            Instantiate(tabPrefab, transform);
        }

        while (transform.childCount > numberOfTabs)
        {
            DestroyImmediate(transform.GetChild(transform.childCount - 1).gameObject);
        }

        // Update the largest tab item width
        widthOfTabItems = new List<float>();
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject tabItem = transform.GetChild(i).GetChild(0).GetChild(1).gameObject;
            widthOfTabItems.Insert(i, tabItem.GetComponent<RectTransform>().sizeDelta.x);
        }
        largestTabItemWidth = Mathf.Max(widthOfTabItems.ToArray());
    }

    public float largestTabItem()
    {
        return largestTabItemWidth;
    }

    public int tabCount()
    {
        return numberOfTabs;
    }
}
