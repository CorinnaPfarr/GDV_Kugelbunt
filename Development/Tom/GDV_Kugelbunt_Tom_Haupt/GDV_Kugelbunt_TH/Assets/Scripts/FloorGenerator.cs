using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {

	// Attachpoints of floor
	public GameObject lFloorPre;
	public GameObject rFloorPre;
	public GameObject tFloorPre;

	public GameObject[] floorArray;

	// Start Floorcube
	public GameObject startCube;

	// Use this for initialization
	void Start () {

		for(int i = 0; i < 2048; i++) {
			spawnPrefab();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnPrefab() {
		// Random nr from 1 to 3
		int randNr = Random.Range(0, 3);

		startCube = (GameObject)Instantiate(floorArray[randNr], startCube.transform.GetChild(0).transform.GetChild(randNr).position, Quaternion.identity);
	}
}
