using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public GameObject explosionPrefab;
	public int explosionType = 1;
	int explosionLength = 5;
	int timer = 0;
	
	void Update () {
		timer++;
		if (timer >= explosionLength && explosionType == 1) {
			Instantiate (explosionPrefab, gameObject.transform.position, Quaternion.identity);
			Destroy (gameObject);
		} 
		else if (timer >= explosionLength && explosionType == 2) {
			Destroy (gameObject);
		}
	}
}
