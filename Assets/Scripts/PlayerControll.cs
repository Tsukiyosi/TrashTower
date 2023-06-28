using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
	[SerializeField] public Sprite clawsLocked;
	[SerializeField] public Sprite clawsUnlocked;
	private SpriteRenderer sr;
	private int currentSprite;
	Vector2 touchFirstPos;
	PrefabSpawner prefSpawner;
	private bool isReadyToSpawn = false;
	private float couldown = 0.5f;

	private void Awake()
	{
		
		prefSpawner = gameObject.GetComponentInChildren<PrefabSpawner>();
		sr = gameObject.GetComponentInChildren<SpriteRenderer>();
	}

	private void Update()
	{
		if (Input.touchCount > 0 && isReadyToSpawn)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				touchFirstPos = Input.touches[0].position;
			}
			else if(Input.touches[0].phase == TouchPhase.Ended)
            {
				if((Input.touches[0].position - touchFirstPos).magnitude <= 30)
                {
					EventManager.SendTapped();
                }
				else if ((Input.touches[0].position - touchFirstPos).magnitude >= 30)
				{
					if(touchFirstPos.x >= Input.touches[0].position.x)
                    {
						EventManager.SendSwipedRight();
                    }
					else if (touchFirstPos.x <= Input.touches[0].position.x)
                    {
						EventManager.SendSwipedLeft();
                    }
                }
            }
		}
	}

	public bool IsReadyToSpawn
	{
		get { return isReadyToSpawn; }
		set { isReadyToSpawn = value; }
	}


	private void SpriteChange()
	{
		if (currentSprite > 1)
		{
			currentSprite = 0;
		}

		if (currentSprite == 0)
			sr.sprite = clawsUnlocked;
		else if (currentSprite == 1)
			sr.sprite = clawsLocked;

		currentSprite++;
		
	}

	private void ReadyToSpawn()
	{
		IsReadyToSpawn = !isReadyToSpawn;
	}

	public void NewPrefab()
	{
		SpriteChange();
		ReadyToSpawn();
		prefSpawner.DropPrefab();
		Invoke("SpriteChange", couldown);
		Invoke("ReadyToSpawn", couldown);
		prefSpawner.Invoke("SpawnPrefab", couldown);

	}
}
