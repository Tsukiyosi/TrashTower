using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ClawsMove : MonoBehaviour
{
	PlayerControll pc;
	[SerializeField] float speed = 15f;
	private Vector3 leftVec;
	private Vector3 rightVec;
	private bool isLeft = false;
	Vector2 startPos = new Vector2(0.05f, 0.9f);
	private bool isReady = false;
	



	private void Awake()
	{
		pc = GetComponent<PlayerControll>();
		Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width, 0)),out RaycastHit hitright, 100);
		rightVec = hitright.point;
		Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(0, 0)), out RaycastHit hitleft, 100);
		leftVec = hitleft.point;

		transform.DOMoveY(startPos.y, 1f).onComplete = new TweenCallback(IsReady);
	}

	private void Update()
	{
		if (transform.position.x <= leftVec.x)
        {
			isLeft = false;
			
        }
		
		if (transform.position.x >= rightVec.x)
		{
			isLeft = true;
			
		}

		if(isReady && pc.IsReadyToSpawn)
        {
			if (isLeft)
			{
				Vector3 pos = new Vector3(transform.position.x - speed, 0, 0); 
				transform.DOMoveX(pos.x, 4f);
			}
			else if (!isLeft)
			{
				Vector3 pos = new Vector3(transform.position.x + speed, 0, 0);
				transform.DOMoveX(pos.x, 4f);
			}
        }
			
	}

	private void IsReady()
    {
		isReady = true;
		pc.IsReadyToSpawn = true;
    }

	
}
