using UnityEngine;

public class WayColliderScript : MonoBehaviour {

	// Collision Function
	void OnCollisionEnter(Collision colObj) {
		Debug.Log(colObj.collider.name + " hited!");
	}
}
