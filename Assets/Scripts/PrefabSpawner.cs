using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
	[SerializeField] public List<PackConfig> AllPacks;
	private List<GameObject> PrefabList = new List<GameObject> { };
	private Rigidbody2D rb;
	private GameObject obj;
	private Vector3 pos;
	GameObject nextPrefab;
	GameObject spawnedPrefab;
	GameObject savedPrefab;
	

    private void Awake()
    {
		foreach(int i in PlayerManager.GetPackId)
        {
			foreach(PackConfig pack in AllPacks)
            {
				if(pack.id == i)
                {
					PrefabList.AddRange(pack.listPrefabs);
					
                }
            }
        }

		spawnedPrefab = PrefabList[Random.Range(0, PrefabList.Count - 1)];
		nextPrefab = PrefabList[Random.Range(0, PrefabList.Count - 1)];
		
		SpawnPrefab();
		EventManager.NextPrefabUpdate();
	}

	public GameObject NextPrefab
    {
		get {return nextPrefab; }
		set { nextPrefab = value; }
    }
	

	public void SelectNextPrefab()
    {
		spawnedPrefab = nextPrefab;
		nextPrefab = PrefabList[Random.Range(0, PrefabList.Count - 1)];
		EventManager.NextPrefabUpdate();
	}

	public void SavePrefab()
    {
		savedPrefab = nextPrefab;
		nextPrefab = PrefabList[Random.Range(0, PrefabList.Count - 1)];
		EventManager.NextPrefabUpdate();
	}

	public void UseSavedPrefab()
    {
		nextPrefab = savedPrefab;
		EventManager.NextPrefabUpdate();
	}

    public void SpawnPrefab()
	{
		obj = Instantiate(spawnedPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))), parent: gameObject.transform);
		obj.transform.localScale = new Vector3(1, 1, 1) * Random.Range(0.8f, 1.2f);
		rb = obj.GetComponent<Rigidbody2D>();
		rb.bodyType = RigidbodyType2D.Kinematic;
		
	}

	public void DropPrefab()
    {
		rb.bodyType = RigidbodyType2D.Dynamic;
		obj.transform.parent = null;
		SelectNextPrefab();
	}
}
