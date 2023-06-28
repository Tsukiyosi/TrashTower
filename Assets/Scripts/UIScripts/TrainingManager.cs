using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrainingManager : MonoBehaviour
{
    [SerializeField] public TMP_Text toSave;
    [SerializeField] public TMP_Text toUse;

    private void Start()
    {
        if (!PlayerManager.IsLearned)
        {
            EventManager.playerSwipedLeft.AddListener(ToSaveEvent);
            toSave.enabled = true;
            
        }
    }

    public void ToSaveEvent()
    {
        EventManager.playerSwipedLeft.RemoveListener(ToSaveEvent);
        EventManager.playerSwipedRight.AddListener(ToUseEvent);
        toSave.enabled = false;
        toUse.enabled = true;
    }

    public void ToUseEvent() {
        EventManager.playerSwipedRight.RemoveListener(ToUseEvent);
        toUse.enabled = false;
        PlayerManager.IsLearned = true;
    }

}
