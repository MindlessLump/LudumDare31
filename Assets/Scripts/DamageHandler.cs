using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

	public GameObject explosionPrefab;
	public int health = 1;
	float invulnTimer = 0;
	public float invulnPeriod = 0;

	int objectLayer;
	float invulnAnim = 0;
	
	public Font f;

	SpriteRenderer spriteRend;

	void Start() {
		objectLayer = gameObject.layer;

		spriteRend = GetComponent<SpriteRenderer> ();
		if (spriteRend == null) {
			spriteRend = transform.GetComponentInChildren<SpriteRenderer>();
		}
	}

	void OnTriggerEnter2D() {
		health--;
		invulnTimer = invulnPeriod;
		gameObject.layer = 10;
	}

	void Update() {
		invulnTimer -= Time.deltaTime;
		if (invulnTimer > 0) {
			if(spriteRend != null) {
				invulnAnim++;
				if(invulnAnim >= 8) {
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
	
	void OnGUI () {
		if (gameObject.layer == 8 || gameObject.layer == 10) {
			GUI.skin.font = f;
			GUI.Label (new Rect (0, 0, 400, 50), "Lives Remaining: " + health + ".");
		}
	}

	void Die() {
		if (gameObject.layer == 9) {
			Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		}
		Destroy (gameObject);
	}
}
