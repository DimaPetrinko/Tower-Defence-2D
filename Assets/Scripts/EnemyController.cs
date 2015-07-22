using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float horizontalSpeed = 0.5f;
	public float verticalSpeed = 0.25f;

	void FixedUpdate () {
		transform.Translate(Vector3.up * Input.GetAxis("Vertical") * verticalSpeed);
		transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * horizontalSpeed);
	}
}
