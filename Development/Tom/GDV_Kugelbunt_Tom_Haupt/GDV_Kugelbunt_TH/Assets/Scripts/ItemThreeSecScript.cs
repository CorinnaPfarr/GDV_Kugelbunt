using System.Collections;
using UnityEngine;

public class ItemThreeSecScript : MonoBehaviour {

	void OnTriggerEnter() {
		Destroy(gameObject);
		Debug.Log("Item collected!");
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(24, 24, 48) * Time.deltaTime);
	}
}
