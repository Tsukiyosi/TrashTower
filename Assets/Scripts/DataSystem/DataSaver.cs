using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[Serializable]
public class DataSaver
{
    public int playerMaxScore = 0;
    public int playerMoney = 0;
    public List<int> selectedPackId = new List<int> { 0 };
    public List<int> boughtPuckId = new List<int> { 0 }; 
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SavedData.dat");
        DataSaver data = new DataSaver();
        data.playerMaxScore = PlayerManager.BestScore;
        data.playerMoney = PlayerManager.Money;
        data.selectedPackId = PlayerManager.GetPackId;
        data.boughtPuckId = PlayerManager.GetBoughtPackId;
        if (PlayerManager.Money == 0)
            data.playerMoney = 30;
        if (PlayerManager.GetPackId == null)
            data.selectedPackId = new List<int> { 0 };
        if (PlayerManager.GetBoughtPackId == null)
            data.boughtPuckId = new List<int> { 0 };
        bf.Serialize(file, data);
        file.Close();
    }
}
