using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	private Rigidbody rb;

	public float speed;

	//public Vector3 playerRePos;

	// Lives amount, must be public static, CHANGE LIVE AMOUNT HERE!!!
	public static int lives = 3;

	// When player collides with item
	void OnCollisionEnter(Collision colObj) {
		if(colObj.gameObject.CompareTag("ItemThree")) {
			//colObj.gameObject.SetActive(false);
			Destroy(colObj.gameObject);
		}
	}

	// Check if player lives are 0, then go to menu
	void Update() {
		if(lives <= 0) {
			// Load Menu
			SceneManager.LoadScene("Menu");
			// Trigger sound
			
		}
	}

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}
}
