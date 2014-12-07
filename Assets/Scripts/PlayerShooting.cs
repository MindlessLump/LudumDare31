using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject bulletPrefab;

	public float fireDelay = 0.2f;
	float cooldownTimer = 0;

	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (Input.GetButton ("Fire1") && cooldownTimer <= 0) {
			cooldownTimer = fireDelay;
			if(Input.GetAxis ("Fire1") > 0) {
				Quaternion rot = Quaternion.Euler (0, 0, 0);
				Instantiate (bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), rot);
			}
			else if(Input.GetAxis ("Fire1") < 0) {
				Quaternion rot = Quaternion.Euler (0, 0, 180);
				Instantiate (bulletPrefab, transform.position + new Vector3(0, -0.5f, 0), rot);
			}
		}
		else if (Input.GetButton ("Fire2") && cooldownTimer <= 0) {
			cooldownTimer = fireDelay;
			if(Input.GetAxis ("Fire2") > 0) {
				Quaternion rot = Quaternion.Euler (0, 0, -90);
				Instantiate (bulletPrefab, transform.position + new Vector3(0.5f, 0, 0), rot);
			}
			else if(Input.GetAxis ("Fire2") < 0) {
				Quaternion rot = Quaternion.Euler (0, 0, 90);
				Instantiate (bulletPrefab, transform.position + new Vector3(-0.5f, 0, 0), rot);
			}
		}
	}
}
