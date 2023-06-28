using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeContoll : MonoBehaviour
{
    [SerializeField] public PrefabSpawner prefSpawner;
    [SerializeField] public Image NextImage;
    [SerializeField] public Image SavedImage;
    
    private GameObject savedPrefab;
    private GameObject nextPrefab;

    public void SavePrefab()
    {
        savedPrefab = nextPrefab;
        SavedImage.enabled = true;
        SavedImage.sprite = savedPrefab.GetComponentInChildren<SpriteRenderer>().sprite;
        prefSpawner.SelectNextPrefab();

    }

    public void ChangeNextPrefab()
    {
        nextPrefab = prefSpawner.NextPrefab;

        NextImage.sprite = nextPrefab.GetComponentInChildren<SpriteRenderer>().sprite;

    }
    public void UseSavedPrefab()
    {
        savedPrefab = null;
        SavedImage.enabled = false;
        prefSpawner.NextPrefab = savedPrefab;
        prefSpawner.UseSavedPrefab();
    }

}
