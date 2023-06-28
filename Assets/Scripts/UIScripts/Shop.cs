using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] public List<PackConfig> packs = new List<PackConfig> { };
    [SerializeField] public GameObject packPref;
    [SerializeField] public TMP_Text money;

    private void Awake()
    {
        money.text = PlayerManager.Money.ToString();
       
        foreach(PackConfig pack in packs)
        {
            ShopHeight.ChangeHeight();
            var pc = Instantiate(packPref, transform).GetComponent<PackController>();
            pc.GetConf(pack);
        }
    }

    private void Update()
    {
        if(PlayerManager.GetPackId.Count == 0)
        {
            PlayerManager.AddPackId = 0;
        }
    }

    public void BackToMenu()
    {
        SaveManager.SavePalyerData();
        SceneManager.LoadScene("MainMenu");
    }
}
