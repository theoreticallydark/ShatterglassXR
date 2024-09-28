using UnityEngine;
using UnityEngine.UI;

public class tabContentManager : MonoBehaviour
{
    public GameObject tabBar;
    tabsStateManager tabsStateManager;
   
    private int currentTabIndex = -1; // Initialize with an invalid index
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tabsStateManager = tabBar.GetComponent<tabsStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int activeTabIndex = tabsStateManager.getActiveTabIndex();
        if (activeTabIndex != currentTabIndex)
        {
            // Tab index has changed, load new content
            LoadContentForTab(activeTabIndex);
            currentTabIndex = activeTabIndex; // Update the current tab index
        }
    }

    void LoadContentForTab(int tabIndex)
    {
        // Your logic to load content for the given tab index
        Debug.Log("Loading content for tab: " + tabIndex);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == tabIndex);
        }

    }
}
