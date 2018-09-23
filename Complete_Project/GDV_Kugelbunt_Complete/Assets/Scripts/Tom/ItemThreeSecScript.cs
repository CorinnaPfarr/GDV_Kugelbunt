using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemThreeSecScript : MonoBehaviour {
	// 
	private UIScript uiScr;

	void Start() {
		uiScr = GameObject.Find("UI").GetComponent<UIScript>();
	}

	void OnTriggerEnter() {
		// Decrease time by 3 seconds
		uiScr.realSec -= 3f;
		// Destroy Item
		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(24, 24, 48) * Time.deltaTime);
	}
}
