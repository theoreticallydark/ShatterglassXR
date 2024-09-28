using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TabsSizeManager : MonoBehaviour
{
    //SAVES LARGEST TAB ITEM SIZE SO THAT TAB ITEMS CAN BE SYNCED

    float largestTabItemlWidth = 0f;
    List<float> widthOfTabItems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        widthOfTabItems = new List<float>();

        for (int i = 0; i < transform.childCount; i++)
        {

            GameObject tabItem = transform.GetChild(i).GetChild(0).GetChild(1).gameObject;
            widthOfTabItems.Insert(i, tabItem.GetComponent<RectTransform>().sizeDelta.x);

        }

        largestTabItemlWidth = Mathf.Max(widthOfTabItems.ToArray());

    }

    public float largestTabItem()
    {
        return largestTabItemlWidth;
    }
}

