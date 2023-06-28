using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
	[SerializeField] public float speed = 3;
	[SerializeField] public GameObject claws;

	


	public void CameraUp(Transform prefab)
	{
		float heightUp =  Vector2.Distance(new Vector2(0,-3f), prefab.transform.position);
		transform.DOMoveY(heightUp, speed);
		claws.transform.DOMoveY(heightUp, speed);
		
	}
}
