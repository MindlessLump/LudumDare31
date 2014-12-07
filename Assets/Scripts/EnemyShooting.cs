using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

	public GameObject bulletPrefab;
	public float fireDelay = 0.5f;
	float cooldownTimer = 0;

	Transform player;

	void Update () {
		cooldownTimer -= Time.deltaTime;

		if (cooldownTimer <= 0) {
			cooldownTimer = fireDelay;
			Vector3 offset = transform.rotation * new Vector3(-0.5f, 0, 0);
			Instantiate (bulletPrefab, transform.position + offset, transform.rotation);
		}
	}
}
