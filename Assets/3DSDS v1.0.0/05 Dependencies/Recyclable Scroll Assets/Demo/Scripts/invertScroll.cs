using PolyAndCode.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using BlinkTalk;
public class invertScroll : MonoBehaviour
{
    private ScrollRect stuff;
    private RectTransform contentBox;
    public RectTransform lastChild;
    void Start()
    {
        stuff = gameObject.GetComponent<RecyclableScrollRect>();
        stuff.content.localPosition = stuff.GetSnapToPositionToBringChildIntoView(lastChild.transform.GetChild(8) as RectTransform);
    }

    private void Update()
    {
        
    }
}


namespace BlinkTalk
{
    public static class ScrollRectExtensions
    {
        public static Vector2 GetSnapToPositionToBringChildIntoView(this ScrollRect instance, RectTransform child)
        {
            Canvas.ForceUpdateCanvases();
            Vector2 viewportLocalPosition = instance.viewport.localPosition;
            Vector2 childLocalPosition = child.localPosition;
            Vector2 result = new Vector2(
                0 - (viewportLocalPosition.x + childLocalPosition.x),
                0 - (viewportLocalPosition.y + childLocalPosition.y)
            );
            return result;
        }
    }
}