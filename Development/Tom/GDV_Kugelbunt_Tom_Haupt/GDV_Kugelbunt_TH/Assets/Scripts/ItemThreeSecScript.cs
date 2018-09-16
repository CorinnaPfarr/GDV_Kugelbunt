using System.Collections;
using UnityEngine;

public class ItemThreeSecScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(24, 24, 48) * Time.deltaTime);
	}
}
