using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeweglicherBlockScript : MonoBehaviour {


    
    
    public bool schalter;  // damit das Objekt nicht sofort aufsteigt
    private float zielHoehe;

	void Start () {

        zielHoehe = 10; //damit das Objekt an einer bestimmten Höhe stehen bleibt
         schalter = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (schalter == true && this.transform.position.y <= zielHoehe)  //bewegt das Objekt
        { transform.Translate(0, Time.deltaTime, 0); }
    }

   public void schalterUmlegen() // diese Funktion wird von dem anderen Objekt aufgerufen wenn dort der Collider berührt wird
    {
        schalter = true;
    }

}
