using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeightManager : MonoBehaviour
{
	private static int height = 0;

	public static int Height
	{
		get { return height; }
		set { height = value; }
	}

}
