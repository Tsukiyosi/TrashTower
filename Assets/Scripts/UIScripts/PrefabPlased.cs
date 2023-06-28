using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrefabPlased : MonoBehaviour
{
    private void Awake()
    {
        EventManager.scoreUpdate.AddListener(UpdateScore);
    }

    private void UpdateScore()
    {
        PlayerManager.CurrentScore += 1;
        GetComponent<TMP_Text>().text = PlayerManager.CurrentScore.ToString();
    }
}
