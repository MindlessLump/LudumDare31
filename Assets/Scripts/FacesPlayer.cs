using UnityEngine;
using System.Collections;

public class FacesPlayer : MonoBehaviour {

	public float rotSpeed = 90f;
	Transform player;

	void Update () {
		// Find the player ship
		if (player == null) {
			GameObject go = GameObject.Find ("PlayerShip");

			if(go != null) {
				player = go.transform;
			}
		}

		// If the player still hasn't been found, try again next frame
		if (player == null)
			return;

		//If the player has been found, turn to face it
		Vector3 dir = player.position - transform.position;
		dir.Normalize ();

		float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
		Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
	}
}
