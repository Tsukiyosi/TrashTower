using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHeight : MonoBehaviour
{   
    static RectTransform rectOfContent;

    private void Awake()
    {
        rectOfContent = gameObject.GetComponent<RectTransform>();
    }

    public static void ChangeHeight()
    {
        rectOfContent.sizeDelta += new Vector2(0, 1500);
    } 
}
