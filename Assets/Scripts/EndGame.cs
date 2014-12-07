using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	GameObject playerInstance;

	void Start () {
		playerInstance = GameObject.Find ("PlayerShip");
	}

	void Update () {
		if (playerInstance == null) {	// If the player ship is no longer in the game
			Application.LoadLevel ("failure");
		}
	}
}
