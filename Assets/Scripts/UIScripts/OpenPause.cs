using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenPause : MonoBehaviour
{
    [SerializeField] public GameObject pause;


	public void Open()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void Close()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}
