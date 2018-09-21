using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherScript : MonoBehaviour {

	// Pusher
	public GameObject pushObj;

	private bool active;

	private float wandEndPos;
	
	void pushWall() {
		pushObj.transform.Translate(Vector3.back * Time.deltaTime * 4);
	}

	void Start() {
		active = true;
		wandEndPos = -1.3f;
		//InvokeRepeating("pushWall", 12.0f, 8.0f);
	}

	// Update is called once per frame
	void Update () {
		if (active == true && this.transform.position.x <= wandEndPos) {
			//transform.Translate(0, Time.deltaTime, 0);
		}
	}
}
