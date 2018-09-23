using System.Collections;
using UnityEngine;

public class ItemThreeSecScript : MonoBehaviour {

	// Time ref
	private float timeRef;

	void OnTriggerEnter() {
		Destroy(gameObject);
		//Debug.Log("Item collected!");
		// Decrease time by 3 seconds
		UIScript.realSec = UIScript.getSeconds() - 3;
		Debug.Log("Time decreased: " +  UIScript.getSeconds());
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(24, 24, 48) * Time.deltaTime);
	}
}
