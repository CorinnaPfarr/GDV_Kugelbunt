using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerfolgerScript : MonoBehaviour
{

    public Transform target;        //in unity sollte der Player als target gesetzt werden
    public MVMT pc; //pc weil es ehemals PlayerControllerscript hieß bevor die Projekte zusammengelegt wurden // -> player muss als Ziel gesetzt werden
    public float verfolgerspeed;
    public float dist;

    void Start()
    {
        verfolgerspeed = .02f; //geschwindigkeit des Verfolgers
        

    }



    void OnTriggerEnter()
    {
        pc.festhalten();

        Destroy(gameObject);
    }

    void Update() {

        dist = Vector3.Distance(target.position, transform.position);  //Abstand zwischen Verfolger und Player
        if (dist <= 30)                     //ab gewissem Abstand mache X
            transform.LookAt(target);       //gucke das target  an

        if (dist <= 15)
        {
            transform.position = Vector3.MoveTowards(transform.position, //verfolge das target
                target.transform.position, verfolgerspeed);
        }
    }

}
