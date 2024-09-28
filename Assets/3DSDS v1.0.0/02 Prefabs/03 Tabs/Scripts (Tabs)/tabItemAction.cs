using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class tabItemAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private MeshRenderer buttonBase; //MeshRenderer
    public tabsStateManager tabsStateManager; // Reference to the TabsStateManager
    private Button button;
    private bool isActive = false;
    private int tabIndex; // Index of this tab item

    void Start()
    {
        buttonBase = gameObject.transform.GetChild(1).GetComponent<MeshRenderer>();
        selectedMaterial = Resources.Load<Material>("Default");
        hoverMaterial = Resources.Load<Material>("Hover");
        unselectedMaterial = Resources.Load<Material>("ui-2");


        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleState);
        // Automatically find the TabsStateManager in the parent GameObject
        tabsStateManager = GetComponentInParent<tabsStateManager>();
        if (tabsStateManager == null)
        {
            Debug.LogError("TabsStateManager not found on the parent GameObject.");
        }
        // Determine the index of this tab item
        tabIndex = transform.GetSiblingIndex();
    }

    // Define the SetTabIndex method
    public void SetTabIndex(int index)
    {
        tabIndex = index;
    }

    void ToggleState()
    {
        // If the tab is already active, do nothing
        if (isActive)
        {
            return;
        }

        // Otherwise, set this tab as active and inform the TabsStateManager
        SetTabActive(true);
        tabsStateManager.UpdateTabState(tabIndex, true);
    }

    public void SetTabActive(bool state)
    {
        isActive = state;
        // Change the button color based on the state
        //button.image.color = isActive ? Color.green : Color.blue;
    }

    private bool isHovered = false;
    private Material hoverMaterial;
    private Material selectedMaterial;
    private Material unselectedMaterial;
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    void Update()
    {
        if (isHovered)
        {
            buttonBase.material = hoverMaterial;
        }

        else if (isActive)
        {
            buttonBase.material = selectedMaterial;
        }

        else
        {
            buttonBase.material = unselectedMaterial;
        }
    }

}
