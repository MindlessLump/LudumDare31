using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5.0f;

	float shipUpperBoundary = 0.4f;
	float shipLowerBoundary = 0.4f;
	float shipSideBoundary = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	// Good for getting user input
	void Update () {		
		//Update the rotation of the ship based on which direction the player is firing
		Quaternion rot = transform.rotation;
		if(Input.GetKeyDown (KeyCode.LeftArrow)) {
			rot = Quaternion.Euler (0, 0, 90);
			transform.rotation = rot;
		}
		if(Input.GetKeyDown (KeyCode.RightArrow)) {
			rot = Quaternion.Euler (0, 0, -90);
			transform.rotation = rot;
		}
		if(Input.GetKeyDown (KeyCode.UpArrow)) {
			rot = Quaternion.Euler (0, 0, 0);
			transform.rotation = rot;
		}
		if(Input.GetKeyDown (KeyCode.DownArrow)) {
			rot = Quaternion.Euler (0, 0, 180);
			transform.rotation = rot;
		}
		
		//Update the vertical and horizontal position of the ship
		Vector3 pos = transform.position;
		float x = maxSpeed * Time.deltaTime * Input.GetAxis ("Horizontal");
		pos.x += x;
		float y = maxSpeed * Time.deltaTime * Input.GetAxis ("Vertical");
		pos.y += y;

		//Restrict the vertical position to within the screen
		if (transform.position.y + shipUpperBoundary > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipUpperBoundary;
		}
		if (transform.position.y - shipLowerBoundary < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipLowerBoundary;
		}

		//Restrict the horizontal position to within the screen
		float screenRatio = (float)Screen.width / Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;
		if (transform.position.x + shipSideBoundary > widthOrtho) {
			pos.x = widthOrtho - shipSideBoundary;
		}
		if (transform.position.x - shipSideBoundary < -widthOrtho) {
			pos.x = -widthOrtho + shipSideBoundary;
		}

		//Set the ship positions within the Unity game
		transform.position = pos;
	}

	// FixedUpdate is called once per tick of the physics engine
	// Good for updating physics information
	void FixedUpdate () {

	}
}
