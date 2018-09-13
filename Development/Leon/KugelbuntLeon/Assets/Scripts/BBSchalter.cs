using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBSchalter : MonoBehaviour {

   

    public BeweglicherBlockScript bbs;

	void Start () {
      //  bbs = GetComponent<BeweglicherBlockScript>();
    }

    void OnTriggerEnter() {
        bbs.schalterUmlegen();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
