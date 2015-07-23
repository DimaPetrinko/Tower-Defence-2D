using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float horizontalSpeed = 0.1f;
	public float verticalSpeed = 0.05f;
	public float health = 100;

	//private TowerController towerController;
	private GameObject enemyPath;
	private Transform[] waypoints;
	private int waypointId = 0;

	void Start () {
		horizontalSpeed /= 10;
		verticalSpeed /= 10;
		enemyPath = GameObjectsManager.enemyPath;//GameObject.FindGameObjectWithTag ("Enemy Path");
		waypoints = EnemySpawner.GetChildren (enemyPath);
	}

	void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	void FixedUpdate () {
		if (waypointId < waypoints.Length) {
			Vector2 direction = waypoints[waypointId].position - transform.position;//вектор напряму, проста геометрія
			if (direction != Vector2.zero) { //якшо ти не на вейпоінті
				//для ілюзії перспективи
				transform.position += new Vector3(direction.normalized.x * horizontalSpeed, direction.normalized.y * verticalSpeed, 0);
				//transform.Translate(new Vector2(direction.x, 0) * horizontalSpeed);
				//transform.Translate(new Vector2(0, direction.y) * verticalSpeed);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.tag == "Waypoint") {
			waypointId++;
		}
		if (waypointId == waypoints.Length) {
			Debug.Log("Game Over");
			Time.timeScale = 0;
			//GameObjectsManager.gameManager.SetActive(false);
		}
	}
}
