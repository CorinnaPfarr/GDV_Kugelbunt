using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	public float horSpd = 1.5f;


	private float yaw = 0.0f;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Calls every frame
	void Update() {
		// Set values to rotate
		yaw += horSpd * Input.GetAxis("Mouse X");

		// Rotate the camera on mouse move, only track X axis
		transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
	}

	// Update is called once per frame, after Update() is finished updating.
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
