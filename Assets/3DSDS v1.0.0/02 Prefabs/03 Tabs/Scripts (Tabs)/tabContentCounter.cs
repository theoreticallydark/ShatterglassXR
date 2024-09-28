using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class tabContentCounter : MonoBehaviour
{


    public GameObject tabContent;
    public GameObject tabBar;
    TabsManager tabsManager;
    int numberOfTabs = 2;
    //[SerializeField, Range(2, 6)] private int numberOfTabs; // Number of tabs

    [SerializeField] private GameObject tabPrefab; // Reference to the Tab Prefab

    private void Start()
    {
        tabsManager = tabBar.GetComponent<TabsManager>();
        numberOfTabs = tabsManager.tabCount();
        UpdateTabs(numberOfTabs);
    }

    private void Update()
    {
        tabsManager = tabBar.GetComponent<TabsManager>();

        numberOfTabs = tabsManager.tabCount();
        UpdateTabs(numberOfTabs);
    }

    private void UpdateTabs(int tabCount)
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

    }
}