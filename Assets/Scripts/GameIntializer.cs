using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIntializer : MonoBehaviour
{
    private bool isIntialized = false;

    private void Awake()
    {
        if (!isIntialized)
        {
            SaveManager.Intialize();
        }
        SaveManager.LoadPalyerData();
        
    }
}
