using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBSchalter : MonoBehaviour {

   

    public BeweglicherBlockScript bbs; //verknüpft sich mit dem anderen script
    private bool geraeusch = true;

	void Start () {
    
    }

    void OnTriggerEnter() {
        
        bbs.schalterUmlegen();
        if(geraeusch == true)
        {
            AudioManager.Instance.Play("lift up");
        }
        geraeusch = false;
    }
	
	void Update () {
		
	}
}
