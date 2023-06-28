using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
	public static UnityEvent scoreUpdate = new UnityEvent();
	public static UnityEvent nextPrefabUpdate = new UnityEvent();
	public static UnityEvent playerLose = new UnityEvent();
	public static UnityEvent playerSwipedLeft = new UnityEvent();
	public static UnityEvent playerSwipedRight = new UnityEvent();
	public static UnityEvent playerTapped = new UnityEvent();
	

	

	public static void NextPrefabUpdate()
    {
		nextPrefabUpdate.Invoke();
    }

	public static void SendSwipedLeft()
    {
		playerSwipedLeft.Invoke();
    }

	public static void SendSwipedRight()
	{
		playerSwipedRight.Invoke();
	}

	public static void SendTapped()
	{
		playerTapped.Invoke();
	}

	public static void SendPrefPlased()
	{
		scoreUpdate.Invoke();
	}
	public static void PlayerLose()
    {
		playerLose.Invoke();
		PlayerManager.Lose();
    }

	
}
