using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public int numberOfEnemies = 1;

	public float spawnDelay = 1f;
	//[HideInInspector]
	public bool begin = true;
	
	private GameObject enemyPath;
	private Transform[] waypoints;
	private bool spawned;
	private int currNumberOfEnemies;

	void Start () {
		enemyPath = GameObjectsManager.enemyPath;
		waypoints = EnemySpawner.GetChildren (enemyPath);
	}
	
	void Update () {
		if (!spawned) {
			if (begin) {
				if (currNumberOfEnemies < numberOfEnemies) {
					StartCoroutine (SpawnEnemy (spawnDelay));
				}
				else {
					begin = false;
					currNumberOfEnemies = 0;
				}
			}
		}
	}

	IEnumerator SpawnEnemy (float seconds){
		waypoints [0].LookAt (waypoints [1].position);
		Instantiate (enemy, new Vector2(waypoints [0].position.x, waypoints [0].position.y), new Quaternion());
		currNumberOfEnemies++;
		spawned = true;
		yield return new WaitForSeconds (seconds);
		spawned = false;
	}

	//Находить дітей
	public static Transform[] GetChildren(GameObject parent)
	{
		Transform a = parent.transform;
		List<Transform> children = new List<Transform>();
		foreach (Transform b in a)
		{
			children.Add(b);
		}
		return children.ToArray();
	}
}
