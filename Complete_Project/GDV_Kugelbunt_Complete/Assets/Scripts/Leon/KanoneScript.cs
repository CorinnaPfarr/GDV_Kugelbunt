﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanoneScript : MonoBehaviour {


    private bool inReichweite =false;
    private  GameObject player;
    public float intervall = 3;
    public GameObject bullet;
    private float ticktack;
    public bool beweglich = true;
    


    void Start () {
     player = GameObject.Find("Player");
     //bullet = GameObject.Find("Projektil");
 
        ticktack = intervall;

        
    }

	
	
	void Update () {

        Vector3 playerPostition = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z); //hier wird sichergelegt, dass sich die Kanone nur auf der Y Achse dreht

        if (inReichweite == true)
        {
            if (beweglich == true) { transform.LookAt(playerPostition); }

           
            ticktack -= Time.deltaTime;
            if (ticktack <= 0f)
            {
             
               // GameObject bullet;
                Instantiate(bullet, transform.position + (player.transform.position - transform.position).normalized, transform.rotation); //das Projektil Prefab wird Instanziert und zwischen Spieler und Objekt platziert
                //AudioManager.Instance.Play("Kanonensound");
                ticktack = intervall;
            }
        }

	}
    
    void OnTriggerEnter()
    {
        inReichweite = true;
    }

    void OnTriggerExit()
    {
        inReichweite = false;
    }
}
