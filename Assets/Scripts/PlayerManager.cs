using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public static class PlayerManager
{
	private static int bestScore = 0;
	private static int money = 0;
	private static int currentScore = 0;
	private static bool isLearned = false;
	private static List<int> selectedPackId = new List<int> { 0 };
	private static List<int> boughtPackId = new List<int> { 0 };

	public static bool IsLearned
    {
		get { return isLearned; }
		set { isLearned = value; }
    }

	public static int BestScore
	{
		get { return bestScore; }
		set { bestScore = value; }
	}
	public static int Money
	{
		get { return money; }
		set { money = value; }
	}

	public static int CurrentScore
	{
		get { return currentScore; }
		set { currentScore = value; }
	}

	public static List<int> GetPackId
	{
		get { return selectedPackId; }
	}   
	
	public static int AddPackId
	{
		set { selectedPackId.Add(value); }
	}
	public static int DeletePackId
	{
		set { selectedPackId.Remove(value); }
	}

	public static List<int> LoadPackId
    {
		set {
			selectedPackId.Clear();
			selectedPackId = value; 
		}
    }

	public static int BuyPackId
    {
		set { boughtPackId.Add(value); }
    }
	public static List<int> GetBoughtPackId
    {
		get { return boughtPackId; }
    }

	public static List<int> LoadBoughtPacksId
    {
        set { 
			boughtPackId.Clear();
			boughtPackId = value;	
		}
    }


	public static void ClearPackId()
	{
		selectedPackId.Clear();
	}




	public static void Lose()
	{
		if (BestScore < CurrentScore)
			BestScore = CurrentScore;

		Money += CurrentScore;

		CurrentScore = 0;
	}
}
