﻿/**  
	Made by Tom Haupt, 21-09-2018.
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {

	// Attachpoints of floor
	public GameObject lFloorPre;
	public GameObject rFloorPre;
	public GameObject tFloorPre;

	// Item with floor
	public GameObject iFloorPre;

	public GameObject[] floorArray;

	// Start Floorcube
	public GameObject floorStart;

	// RigidBody of player
	public Rigidbody rbPlayer;

	// Player Ref
	public GameObject player;

	// Prefab generated coordinates
	private float xPrePos; // X Axis
	private float yPrePos; // Y Axis
	private float zPrePos; // Z Axis

	// Max nr. of items to spawn, max nr. of pushers to spawn
	private int maxRandNr;
	private int maxRandPushNr;

	// List for generated prefabs
	public List<GameObject> prefabList = new List<GameObject>();

	// Set endCube, endCubeRotator as global for update()
	private GameObject endCubeRotator;
	private GameObject endCube;

	// Set light global
	private GameObject endLight1;
	private GameObject endLight2;
	private GameObject endLight3;
	private GameObject endLight4;
	private Light endLightComp1;
	private Light endLightComp2;
	private Light endLightComp3;
	private Light endLightComp4;

	// runningNr of prefabs
	private int runningNr;

	// levelLength nr
	private int levelLength;

	// Last Generated Prefab, to get x,y,z axis
	private GameObject lastPrefab;

	// Method that returns the percentage of the distance between the player and the endlight
	float getDistance(float lightPos, float playerPos) {
		return (playerPos * 100) / lightPos;
	}

	// Use this for initialization
	void Start () {

		// Set levelLength to 1024
		levelLength = 1024;

		// Set prefab runningNr
		runningNr = 0;

		// Set maxrandomnr
		maxRandNr = 0;
		maxRandPushNr = 0;

		// Init RigidBody of player
		rbPlayer = player.GetComponent<Rigidbody>();

		// Generate StartCube, EndCube
		GameObject startCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		endCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		endCubeRotator = GameObject.CreatePrimitive(PrimitiveType.Cube);

		// Generate EndCube lights
		endLight1 = new GameObject("EndLight1");
		endLightComp1 = endLight1.AddComponent<Light>();

		endLight2 = new GameObject("EndLight2");
		endLightComp2 = endLight2.AddComponent<Light>();

		endLight3 = new GameObject("EndLight3");
		endLightComp3 = endLight3.AddComponent<Light>();

		endLight4 = new GameObject("EndLight4");
		endLightComp4 = endLight4.AddComponent<Light>();

		// Set endLight settings
		endLightComp1.type = LightType.Spot;
		endLightComp1.color = Color.white;

		endLightComp2.type = LightType.Spot;
		endLightComp2.color = Color.white;

		endLightComp3.type = LightType.Spot;
		endLightComp3.color = Color.white;

		endLightComp4.type = LightType.Spot;
		endLightComp4.color = Color.white;

		// Init Material for StartCube, endCube
		Material floorMat = Resources.Load("Floor", typeof(Material)) as Material;
		Material floorMatEnd = Resources.Load("FloorEnd", typeof(Material)) as Material;

		// Set Material of startCube, endCube
		startCube.GetComponent<Renderer>().material = floorMat;
		endCube.GetComponent<Renderer>().material = floorMat;
		endCubeRotator.GetComponent<Renderer>().material = floorMatEnd;

		// Set StartCube, endCube Size
		startCube.transform.localScale = new Vector3(8.0f, 0.5f, 8.0f);
		endCube.transform.localScale = new Vector3(8.0f, 0.5f, 8.0f);
		endCubeRotator.transform.localScale = new Vector3(2.0f, 0.1f, 2.0f);

		// Set name of startCube, endCube
		startCube.name = "StartCube";
		endCube.name = "EndCube";
		endCubeRotator.name = "EndCubeRotator";

		// Check that cubes are not on the same coordinates!
		for(int i = 0; i < levelLength; i++) {
			spawnPrefab();
			runningNr++;
		}

		// Spawn endCube at last prefab!
		lastPrefab = prefabList[levelLength-1];

		// Set position of the startCube at origin to catch player
        startCube.transform.position = new Vector3(0, 0, 0);
		// Set endcube at location of prefab
		endCube.transform.position = new Vector3(lastPrefab.transform.position.x + lastPrefab.transform.localScale.x, lastPrefab.transform.position.y, lastPrefab.transform.position.z + lastPrefab.transform.localScale.x);
		// Set Rotator at same x and z coordinates
		endCubeRotator.transform.position = new Vector3(endCube.transform.position.x, (endCube.transform.position.y) + 0.25f, endCube.transform.position.z);
		// Set endLight positions
		endLight1.transform.position = new Vector3(endCube.transform.position.x + 2.0f, 0.5f, endCube.transform.position.z + 0.0f);
		endLight2.transform.position = new Vector3(endCube.transform.position.x + -2.0f, 0.5f, endCube.transform.position.z + 0.0f);
		endLight3.transform.position = new Vector3(endCube.transform.position.x + 0.0f, 0.5f, endCube.transform.position.z + 2.0f);
		endLight4.transform.position = new Vector3(endCube.transform.position.x + 0.0f, 0.5f, endCube.transform.position.z + -2.0f);
		// Rotate spot lights
		endLight1.transform.Rotate(-85.0f, 0.0f, 0.0f);
		endLight2.transform.Rotate(-85.0f, 0.0f, 0.0f);
		endLight3.transform.Rotate(-85.0f, 0.0f, 0.0f);
		endLight4.transform.Rotate(-85.0f, 0.0f, 0.0f);

		// add cubes for more beautiful level later?
		//lastPrefab.transform.localScale = new Vector3(4.0f, 200.0f, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// Set endLight intensity if player moves
		if(rbPlayer.velocity.magnitude > 0) {
			// Rotate the endCube Rotator on the y axis
			endCubeRotator.transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime);

			// Set Y value of Rotator and set its position
			endCubeRotator.transform.localScale = new Vector3(2.0f, getDistance(endCubeRotator.transform.position.z, player.transform.position.z), 2.0f);
			endCubeRotator.transform.position = new Vector3(endCube.transform.position.x, getDistance(endCubeRotator.transform.position.z, player.transform.position.z) / 2, endCube.transform.position.z);

			// Set endLights Intensity
			endLightComp1.intensity = getDistance(endCubeRotator.transform.position.z, player.transform.position.z) / 4;
			endLightComp2.intensity = getDistance(endCubeRotator.transform.position.z, player.transform.position.z) / 4;
			endLightComp3.intensity = getDistance(endCubeRotator.transform.position.z, player.transform.position.z) / 4;
			endLightComp4.intensity = getDistance(endCubeRotator.transform.position.z, player.transform.position.z) / 4;
			// Rotate endLights with the endCubeRotator
			endLight1.transform.RotateAround(endCubeRotator.transform.position, Vector3.up, 45 * Time.deltaTime);
			endLight2.transform.RotateAround(endCubeRotator.transform.position, Vector3.up, 45 * Time.deltaTime);
			endLight3.transform.RotateAround(endCubeRotator.transform.position, Vector3.up, 45 * Time.deltaTime);
			endLight4.transform.RotateAround(endCubeRotator.transform.position, Vector3.up, 45 * Time.deltaTime);
		}
	}

	public void spawnPrefab() {
		// Random nr from 0 to 2?
		int randNr = Random.Range(0, 5);
		int randOK = Random.Range(0, 100);

		//Debug.Log("random: " + randNr);
		//Debug.Log("random OK: " + randOK);

		if(randNr == 3 && maxRandNr < 20 && randOK % 5 == 0) {
			// If random int is 3 AND randNrMax is lower than 20 AND random nr between 0-100 is dividable by 5, spawn item.
			floorStart = (GameObject)Instantiate(floorArray[randNr], floorStart.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
			maxRandNr++;
		} else if(randNr == 4 && maxRandPushNr < 10 && randOK % 12 == 0) {
			// If random int is 4 AND maxRandPushNr is lower than 5 AND random nr between 0-100 is dividable by 2, spawn pusher.
			floorStart = (GameObject)Instantiate(floorArray[randNr], floorStart.transform.GetChild(0).transform.GetChild(1).position, Quaternion.identity);
			maxRandPushNr++;
		} else {
			// Spawn standard floorPrefabs and set randomNr Range to 0-2
			randNr = Random.Range(0, 3);
			floorStart = (GameObject)Instantiate(floorArray[randNr], floorStart.transform.GetChild(0).transform.GetChild(randNr).position, Quaternion.identity);
		}

		// Assign Prefab a Name for later calling.
		floorStart.name = "generatedPrefab#" + runningNr;
		// Add prefab to prefabList
		prefabList.Insert(runningNr, floorStart);
	}

}