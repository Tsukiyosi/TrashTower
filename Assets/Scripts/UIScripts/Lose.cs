using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lose : MonoBehaviour
{
    [SerializeField] public GameObject lose;

    private void Awake()
    {
        lose.SetActive(false);
        EventManager.playerLose.AddListener(PlayerLosed);
    }

    private void Update()
    {
        foreach( Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                OpenMainMenu();
            }
        }
       
    }

    private void PlayerLosed()
    {
        lose.SetActive(true);
        Time.timeScale = 0;
    }

    private void OpenMainMenu()
    {
        
        Time.timeScale = 1;
        SaveManager.SavePalyerData();
        SceneManager.LoadScene("MainMenu");
    }
}
