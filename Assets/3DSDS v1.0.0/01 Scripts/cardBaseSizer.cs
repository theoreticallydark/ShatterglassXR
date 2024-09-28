using UnityEngine;

[ExecuteInEditMode]
public class CardBaseSizer : MonoBehaviour
{
    private RectTransform parentCanvas;

    private void Start()
    {
        // Get the parent canvas
        parentCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Get the size of the parent canvas
        float canvasWidth = parentCanvas.rect.width;
        float canvasHeight = parentCanvas.rect.height;

        // Set the scale of the 0th child (child0)
        transform.GetChild(0).localScale = new Vector3(canvasWidth / 100f, canvasHeight / 100f, transform.GetChild(0).localScale.z);

        // Set the scale of the 1st child (child1)
        transform.GetChild(1).localScale = new Vector3(canvasWidth / 100f, canvasHeight / 100f, transform.GetChild(1).localScale.z);

    }
}
