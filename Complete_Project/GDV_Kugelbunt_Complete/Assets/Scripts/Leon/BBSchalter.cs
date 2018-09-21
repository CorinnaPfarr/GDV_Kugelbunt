using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBSchalter : MonoBehaviour {

   

    public BeweglicherBlockScript bbs; //verknüpft sich mit dem anderen script

	void Start () {
    
    }

    void OnTriggerEnter() {
        bbs.schalterUmlegen();
    }
	
	void Update () {
		
	}
}
