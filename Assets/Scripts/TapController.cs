using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TapController : MonoBehaviour
{
    [SerializeField] public SwipeContoll swControll;
    PlayerControll plControll;
    private void Awake()
    {
        plControll = GetComponent<PlayerControll>();
        EventManager.playerSwipedLeft.AddListener(UseSavedPrefab);
        EventManager.playerSwipedRight.AddListener(SavePrefab);
        EventManager.playerTapped.AddListener(DropPrefab);
        EventManager.nextPrefabUpdate.AddListener(NextPrefab);
    }


    public void SavePrefab()
    {
        swControll.SavePrefab();
    }

    public void UseSavedPrefab()
    {
        swControll.UseSavedPrefab();
    }

    public void NextPrefab()
    {
        swControll.ChangeNextPrefab();
    }

    public void DropPrefab()
    {
        plControll.NewPrefab();
    }
}
