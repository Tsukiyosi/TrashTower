using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class DataLoader
{
    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavedData.dat", FileMode.Open);
            DataSaver data = (DataSaver)bf.Deserialize(file);
            file.Close();
            PlayerManager.BestScore = data.playerMaxScore;
            PlayerManager.Money = data.playerMoney;
            PlayerManager.LoadPackId = data.selectedPackId;
            PlayerManager.LoadBoughtPacksId = data.boughtPuckId;
            if (data.playerMoney == 0)
                PlayerManager.Money = 30;
            if (data.selectedPackId == null)
                PlayerManager.LoadPackId = new List<int> { 0 };
            if (data.boughtPuckId == null)
                PlayerManager.LoadBoughtPacksId = new List<int> { 0 };
        }
    }
}
