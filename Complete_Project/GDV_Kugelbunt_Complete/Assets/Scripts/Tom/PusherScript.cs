using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherScript : MonoBehaviour {
	//bool active = true;

	private float speed = 120.0f;
	private float force = 200.0f;

	// Material
	private Material red;

	void Start() {
		StartCoroutine(moveWallLeft());
	}

	void Update() {
		
	}

	void OnTriggerEnter(Collider colObj) {
		if (colObj.gameObject.CompareTag("Player")) {
			//Debug.Log("Player pushed!");
			colObj.gameObject.GetComponent<Rigidbody>().AddForce (force, 0, 0);
			// First set Material than change it
			red = Resources.Load("Tom/PusherMatTrig", typeof(Material)) as Material;
			this.GetComponent<Renderer>().material = red;
		}
	}

	IEnumerator moveWallLeft() {
		// Move object
		this.transform.GetChild(1).Translate(Vector3.back * Time.deltaTime * speed);
		// Wait two seconds
		yield return new WaitForSeconds(2);
		// Recursive call
		StartCoroutine(moveWallRight());
	}

	IEnumerator moveWallRight() {
		// Move object
		this.transform.GetChild(1).Translate(Vector3.forward * Time.deltaTime * speed);
		// Wait two seconds
		yield return new WaitForSeconds(2);
		// Recursive call
		StartCoroutine(moveWallLeft());
	}
}
