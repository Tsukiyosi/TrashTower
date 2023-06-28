using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class SaveManager
{
    static DataSaver ds;
    static DataLoader dl;

    public static void Intialize()
    {
        ds = new DataSaver();
        dl = new DataLoader();
    }

    public static void SavePalyerData()
    {
        ds.SaveData();
    }

    public static void LoadPalyerData()
    {
        dl.LoadData();
    }
}
