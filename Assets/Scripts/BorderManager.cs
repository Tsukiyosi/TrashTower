using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour
{
    private List<GameObject> inTriggerObjects = new List<GameObject>();
    [SerializeField] public CameraManager cameraManager;
    PrefabManager prefManOnObj;



    private void FixedUpdate()
    {
        Transform highestObj = null;
        foreach (GameObject obj in inTriggerObjects)
        {
            if (obj.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
            {
                if (highestObj != null)
                {
                    if (obj.transform.position.y > highestObj.position.y)
                        highestObj = obj.transform;
                }
                else
                    highestObj = obj.transform;

            }
        }

        if (highestObj != null)
        {
            cameraManager.CameraUp(highestObj);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!inTriggerObjects.Exists(x=>x == collision.gameObject))
        {
            inTriggerObjects.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (inTriggerObjects.Exists(x => x == collision.gameObject))
        {
            inTriggerObjects.Remove(collision.gameObject);
        }
    }
}
