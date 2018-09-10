﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position + player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () { //lateupdate läuft nach update, also nachdem der Player sich bewegt hat
        transform.position = player.transform.position + offset;

     //   transform.LookAt(player.transform);
    }
}
