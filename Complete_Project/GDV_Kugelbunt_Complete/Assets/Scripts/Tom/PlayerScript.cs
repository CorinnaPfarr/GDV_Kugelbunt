using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	private Rigidbody rb;

	public float speed;

	public Vector3 playerRePos;

	// When player collides with item
	void OnCollisionEnter(Collision colObj) {
		if(colObj.gameObject.CompareTag("ItemThree")) {
			//colObj.gameObject.SetActive(false);
			Destroy(colObj.gameObject);
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
