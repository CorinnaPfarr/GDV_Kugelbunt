using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HochRunterBlockScript : MonoBehaviour {


    public float zurueckgelegt;
    public float strecke = 40;
    public float speed = 10;
    public float ticktack;
    public float intervall = 1;
    public bool nachOben = true;
    public bool intervallAn = false;
    Vector3 lastPosition;


    void Start()
    {
        lastPosition = transform.position;
        ticktack = intervall;
    }


    void Update()
    {

        if (intervallAn == true)
        {
            ticktack -= Time.deltaTime;
            if (ticktack <= 0)
            {
                nachOben = !nachOben;
                ticktack = intervall;
                zurueckgelegt = 0;
                lastPosition = transform.position;

                intervallAn = false;
                
            }

        }
    }
    void FixedUpdate()
    {

        if (nachOben == true && zurueckgelegt <= strecke)
        {

            transform.Translate( 0, Time.deltaTime * speed, 0);
            zurueckgelegt += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;

            if (zurueckgelegt >= strecke)
            {
                
                intervallAn = true;
            }


        }

        if (nachOben == false && zurueckgelegt <= strecke)
        {

            transform.Translate( 0, -Time.deltaTime * speed, 0);
            zurueckgelegt += Vector3.Distance(transform.position, lastPosition);
            lastPosition = transform.position;

            if (zurueckgelegt >= strecke)
            {
                
                intervallAn = true;

            }
        }



    }
}
