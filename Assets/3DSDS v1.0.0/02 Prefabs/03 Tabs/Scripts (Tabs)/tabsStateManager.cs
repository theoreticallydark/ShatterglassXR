using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class tabsStateManager : MonoBehaviour
{
    private List<tabItemAction> tabItems = new List<tabItemAction>();
    private int activeTabIndex = -1; // -1 indicates no tab is active

    void Start()
    {
        // Initialize the list with all tab items
        for (int i = 0; i < transform.childCount; i++)
        {
            tabItemAction tabItemAction = transform.GetChild(i).GetComponent<tabItemAction>();
            if (tabItemAction != null)
            {
                tabItems.Add(tabItemAction);
                tabItemAction.SetTabIndex(i); // Set the index in TabItemAction
            }
        }

        // Activate the first tab by default if it exists
        if (tabItems.Count > 0)
        {
            ActivateTab(0);
        }
    }

    public void UpdateTabState(int tabIndex, bool isActive)
    {
        if (isActive)
        {
            // If there is an active tab, deactivate it
            if (activeTabIndex != -1)
            {
                tabItems[activeTabIndex].SetTabActive(false);
                OnTabDeactivated(activeTabIndex);
            }
            // Set the new active tab
            activeTabIndex = tabIndex;
            OnTabActivated(activeTabIndex);
        }
        else if (activeTabIndex == tabIndex)
        {
            // If the active tab is being deactivated, clear the active tab
            OnTabDeactivated(activeTabIndex);
            activeTabIndex = -1;
        }
    }

    private Material selectedMaterial;
    private Material unselectedMaterial;
    private MeshRenderer buttonBase;
    RectTransform rectTransform;
    int currentTabIndex;
    // Method called when a tab is activated
    private void OnTabActivated(int tabIndex)
    {
        currentTabIndex = tabIndex;
        // Perform actions on the newly activated tab
        //Debug.Log("Tab at index " + tabIndex + " was activated.");
        selectedMaterial = Resources.Load<Material>("Default");
        buttonBase = gameObject.transform.GetChild(tabIndex).GetChild(1).GetComponent<MeshRenderer>();
        buttonBase.material = selectedMaterial;
        // Add additional logic here as needed
        StartCoroutine(lerpActive());
    }

    // Method called when a tab is deactivated

    private void OnTabDeactivated(int tabIndex)
    {

        // Perform actions on the deactivated tab
        //Debug.Log("Tab at index " + tabIndex + " was deactivated.");
        unselectedMaterial = Resources.Load<Material>("ui-2");
        buttonBase = gameObject.transform.GetChild(tabIndex).GetChild(1).GetComponent<MeshRenderer>();
        buttonBase.material = unselectedMaterial;
        // Add additional logic here as needed
        StartCoroutine(lerpDeactive());
    }

    // Helper method to activate a tab by index
    private void ActivateTab(int index)
    {
        tabItems[index].SetTabActive(true);
        activeTabIndex = index;
        OnTabActivated(index);
    }

    private float lerpDuration = .48f;
    IEnumerator lerpActive()
    {

        GameObject activeTab = gameObject.transform.GetChild(currentTabIndex).gameObject;
        rectTransform = activeTab.GetComponent<RectTransform>();
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y, Mathf.Lerp(0f, 3.5f, timeElapsed / lerpDuration));
            //Debug.Log("Position = " + rectTransform.localPosition);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y, 3.5f);
        //Debug.Log("Reached End Position");

    }

    IEnumerator lerpDeactive()
    {
        GameObject activeTab = gameObject.transform.GetChild(currentTabIndex).gameObject;
        RectTransform rectTransform = activeTab.GetComponent<RectTransform>();
        float duration = 0.48f;
        float time = 0;
        Vector3 startPosition = rectTransform.localPosition;
        Vector3 endPosition = new Vector3(startPosition.x, startPosition.y, 0f);

        while (time < duration)
        {
            float t = time / duration;
            t = Mathf.SmoothStep(0.0f, 1.0f, t); // Using SmoothStep for a smoother lerp
            rectTransform.localPosition = new Vector3(startPosition.x, startPosition.y, Mathf.Lerp(3.5f, 0f, t));
            time += Time.deltaTime;
            yield return null;
        }
        rectTransform.localPosition = endPosition; // Ensure it ends at the exact position
    }


    public int getActiveTabIndex()
    {
        return activeTabIndex;
    }
}
