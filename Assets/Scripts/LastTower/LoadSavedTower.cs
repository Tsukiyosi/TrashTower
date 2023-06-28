using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSavedTower : MonoBehaviour
{
    private float gameHeight = -2f;
    private float menuHeight = -0.82f;

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Game")
            Load(gameHeight);
        else if (SceneManager.GetActiveScene().name == "MainMenu")
            Load(menuHeight);
    }

    private void Load(float height)
    {
        if (SaveLastTower.GetLastTower != null)
        {
            transform.position = new Vector3(0, 0, 0);
            List<GameObject> objects = new List<GameObject>();
            foreach (var obj in SaveLastTower.GetLastTower)
            {
                var instObj = Instantiate(new GameObject());
                instObj.transform.position = obj.position;
                instObj.transform.localScale = obj.scale;
                instObj.transform.rotation = Quaternion.Euler(obj.rotation);
                instObj.AddComponent<SpriteRenderer>().sprite = obj.sprite;
                objects.Add(instObj);
            }
            foreach (var obj in objects)
            {
                obj.transform.parent = transform;
                obj.GetComponent<SpriteRenderer>().color = new Color(70f / 256f, 70f / 256f, 70f / 256f);
            }
            objects.Clear();

            transform.localScale = new Vector2(0.5f, 0.5f);
        }

        transform.position = new Vector3(-2.4f, height, -1);

        if (SceneManager.GetActiveScene().name == "Game")
            SaveLastTower.ClearLastTower();
    }

}
