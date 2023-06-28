using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLastTower: MonoBehaviour
{
    private static List<ObjInLastTower> savedTower = new List<ObjInLastTower>();
    
    public static List<ObjInLastTower> GetLastTower
    {
        get { return savedTower; }
    }
    public static void ClearLastTower()
    {
        savedTower.Clear();
    }

    public static GameObject AddObjToLastTower
    {
        set { var obj = new ObjInLastTower();
            obj.sprite = value.GetComponentInChildren<SpriteRenderer>().sprite;
            obj.position = value.transform.position;
            obj.scale = value.transform.localScale;
            obj.rotation = value.transform.rotation.eulerAngles;
            savedTower.Add(obj);
        }
    }
}
