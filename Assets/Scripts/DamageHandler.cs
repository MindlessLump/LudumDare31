using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public int health = 1;
	float invulnTimer = 0;
	public float invulnPeriod = 0;

	int objectLayer;
	float invulnAnim = 0;

	SpriteRenderer spriteRend;

	void Start() {
		objectLayer = gameObject.layer;

		spriteRend = GetComponent<SpriteRenderer> ();
		if (spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
		}
	}

	void OnTriggerEnter2D() {
		Debug.Log ("Trigger!");

		health--;
		invulnTimer = invulnPeriod;
		gameObject.layer = 10;
	}

	void Update() {
		invulnTimer -= Time.deltaTime;
		if (invulnTimer > 0) {
			if(spriteRend != null) {
				invulnAnim++;
				if(invulnAnim >= 4) {
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}
		if(invulnTimer <= 0) {
			gameObject.layer = objectLayer;
			if(spriteRend != null) {
				spriteRend.enabled = true;
			}
		}

		if (health <= 0) {
			Die();
		}
	}

	void Die() {
		Destroy (gameObject);
	}
}
