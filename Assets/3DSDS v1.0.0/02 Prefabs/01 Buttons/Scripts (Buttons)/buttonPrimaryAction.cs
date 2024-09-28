using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class buttonPrimaryAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private MeshRenderer buttonBase; //MeshRenderer
    private Material hoverMaterial;
    private Material defaultMaterial;
    RectTransform rectTransform;
    private float lerpDuration = .24f;
    private bool isLerping = false;
    private bool isHovered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonBase = gameObject.transform.GetChild(1).GetComponent<MeshRenderer>();
        defaultMaterial = Resources.Load<Material>("Default");
        hoverMaterial = Resources.Load<Material>("Hover");
        rectTransform = GetComponent<RectTransform>();
        gameObject.GetComponent<Button>().onClick.AddListener(buttonPress);
    }

    void buttonPress()
    {
        if (!isLerping)
        {
            Debug.Log("Button is Pressed");
            StartCoroutine(lerpButton());
        }
    }

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
        if (isHovered || isLerping)
        {
            buttonBase.material = hoverMaterial;
        }

        else
        {
            buttonBase.material = defaultMaterial;  
        }
    }
    IEnumerator lerpButton()
    {
        isLerping = true;
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y, Mathf.Lerp(0f, 7.5f, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        //transform.localPosition = endLocalPosition;
        Debug.Log("Reached End Position");

        // Wait for a moment before moving back
        yield return new WaitForSeconds(0.1f);

        timeElapsed = 0; // Reset timeElapsed for the reverse lerp
        while (timeElapsed < lerpDuration)
        {
            rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y, Mathf.Lerp(7.5f, 0f, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, rectTransform.localPosition.y, 0);
        Debug.Log("Returned to Start Position");
        isLerping = false;
    }


}
