﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelVorbei : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void  OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        print("Ende :)");
    }
}
