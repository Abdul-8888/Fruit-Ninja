using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
	public GameObject fruit;
	public Transform[] spawnPoints;
	public float minDelay = 1f;
	public float maxDelay = 2f;

	private bool enableFruits = true;
	private Rigidbody rb;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(ThrowFruits());
	}

	IEnumerator ThrowFruits()
	{
		while (enableFruits)
		{
			yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

			int spawnIndex = Random.Range(0,spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawned = Instantiate(fruit, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawned, 3f);			

		}

	}
}
