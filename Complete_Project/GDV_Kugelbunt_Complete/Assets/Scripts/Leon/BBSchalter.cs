using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBSchalter : MonoBehaviour {

   

    public BeweglicherBlockScript bbs; //verknüpft sich mit dem anderen script

	void Start () {
    
    }

    void OnTriggerEnter() {
        //AudioManager.Instance.Play("lift up");
        bbs.schalterUmlegen();
    }
	
	void Update () {
		
	}
}
