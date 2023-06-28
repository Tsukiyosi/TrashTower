using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PrefabManager : MonoBehaviour
{
	private Rigidbody2D rb;
	bool isCollision = false;
	bool isStatic = false;
	SpriteRenderer sp;
	Timer timer;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		sp = GetComponentInChildren<SpriteRenderer>();
	}

	private void Update()
	{
		timer?.Update();
        if (!isStatic)
        {
			MakeCollisionStatic();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		isCollision = true;

		if (collision.gameObject.CompareTag("DeathFloor"))
        {
			EventManager.PlayerLose();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("DeathFloor"))
		{
			EventManager.PlayerLose();
		}
	}


    private void MakeCollisionStatic()
    {
		if( timer != null)
        {
			if (Mathf.Abs(rb.velocity.y) >= 0.1f && Mathf.Abs(rb.angularVelocity) >= 0.1f)
            {
				timer = null;
            }

		}
        else if (isCollision && !isStatic)
        {
			if (Mathf.Abs(rb.velocity.y) <= 0.1f && Mathf.Abs(rb.angularVelocity) <= 0.1f)
			{

				timer = new Timer(.7f);

				timer.OnTimesUp.AddListener(DoStatic);
				
			}
		}
			
	}

	private void DoStatic()
    {
		timer = null;
		rb.bodyType = RigidbodyType2D.Static;
		EventManager.SendPrefPlased();
		isStatic = true;
		sp.DOColor( new Color(123f / 256f, 104f / 256f, 104f / 256f), .5f);
	}

    private void OnCollisionExit2D(Collision2D collision)
	{
		isCollision = false;
	}
}
