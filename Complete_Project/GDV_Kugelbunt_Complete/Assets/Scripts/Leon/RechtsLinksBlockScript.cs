using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechtsLinksBlockScript : MonoBehaviour {

    public float zurueckgelegt;
    public float strecke = 40;
    public float speed = 10;
    public float ticktack;
    public float intervall = 1;
    public bool nachRechts = true;
    public bool intervallAn = false;
    Vector3 lastPosition;
  

	void Start () {
        lastPosition = transform.position;
        ticktack = intervall;
    }
	

	void Update () {

        if (intervallAn == true)
        {
            ticktack -= Time.deltaTime;
            if (ticktack <= 0)
            {
                nachRechts = !nachRechts;
                ticktack = intervall;
                zurueckgelegt = 0;
                lastPosition = transform.position;

                intervallAn = false;
                
            }

        }
    }
    void FixedUpdate()
    {

        if (nachRechts == true && zurueckgelegt <= strecke)
        {

            transform.Translate(Time.deltaTime * speed, 0, 0);
            zurueckgelegt += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;

            if (zurueckgelegt >= strecke)
            {
                
                intervallAn = true;
            }


        }

          if (nachRechts == false && zurueckgelegt <= strecke)
            {
                
                transform.Translate(-Time.deltaTime * speed, 0, 0);
                zurueckgelegt += Vector3.Distance(transform.position, lastPosition);
                lastPosition = transform.position;

                if (zurueckgelegt >= strecke)
                {
                
                intervallAn = true;
                    
                }
            }


        
    }
}
