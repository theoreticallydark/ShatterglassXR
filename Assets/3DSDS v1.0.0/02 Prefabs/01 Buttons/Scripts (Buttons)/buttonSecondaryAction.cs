using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using TMPro;

public class buttonSecondaryAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rectTransform;
    Button button;
    private Vector3 startLocalPosition;
    private Vector3 endLocalPosition;
    [SerializeField] float lerpDuration = .24f;
    private bool isLerping = false;
    private bool isHovered = false;
    private Color startColor = new Color(0, 0.8f, 0.8f); // #00cccc
    private Color hoverColor = new Color(0, 1f, 0.725f); // #00ffb9
    Image image;



    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = gameObject.GetComponent<Image>(); // Get the Image component
        image.color = startColor;
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(buttonPress);
        startLocalPosition = rectTransform.localPosition;
        endLocalPosition = startLocalPosition + new Vector3(0, 0, 7.5f);
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
        isHovered=false;
    }

    void Update()
    {
        if (isHovered || isLerping)
        {
            image.color = hoverColor;

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);

                // Try to get an Image component on the child
                Image image = child.GetComponent<Image>();
                if (image != null)
                {
                    // If found, change its color to startColor
                    image.color = hoverColor;
                    continue; // Skip to the next iteration
                }

                // Try to get a TextMeshProUGUI component on the child
                TextMeshProUGUI textMesh = child.GetComponent<TextMeshProUGUI>();
                if (textMesh != null)
                {
                    // If found, change its color to startColor
                    textMesh.color = hoverColor;
                }
            }

    }

        else
        {
            image.color = startColor;
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);

                // Try to get an Image component on the child
                Image image = child.GetComponent<Image>();
                if (image != null)
                {
                    // If found, change its color to startColor
                    image.color = startColor;
                    continue; // Skip to the next iteration
                }

                // Try to get a TextMeshProUGUI component on the child
                TextMeshProUGUI textMesh = child.GetComponent<TextMeshProUGUI>();
                if (textMesh != null)
                {
                    // If found, change its color to startColor
                    textMesh.color = startColor;
                }
            }

        }
    }
    IEnumerator lerpButton()
    {
        isLerping = true;
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            rectTransform.localPosition = Vector3.Lerp(startLocalPosition, endLocalPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.localPosition = endLocalPosition;
        Debug.Log("Reached End Position");

        yield return new WaitForSeconds(0.1f);

        timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            rectTransform.localPosition = Vector3.Lerp(endLocalPosition, startLocalPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        rectTransform.localPosition = startLocalPosition;
        Debug.Log("Returned to Start Position");
        isLerping = false;
    }
}
