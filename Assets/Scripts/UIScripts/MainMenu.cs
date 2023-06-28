using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public TMP_Text bestScore;
    [SerializeField] public TMP_Text money;
    public bool canLoad = false;

    private void Awake()
    {
        bestScore.text = "BEST: " + PlayerManager.BestScore;
        money.text = PlayerManager.Money.ToString();
        Invoke("CanLoad", 0.2f);
    }

    public void CanLoad()
    {
        canLoad = true;
    }

    public void OpenGame()
    {
        if (canLoad)
            SceneManager.LoadScene("Game");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("ShopMenu");  
    }
}
