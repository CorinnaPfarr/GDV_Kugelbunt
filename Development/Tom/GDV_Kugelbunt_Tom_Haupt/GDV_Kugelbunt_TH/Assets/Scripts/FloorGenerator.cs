/**  
	Made by Tom Haupt, 19-09-2018.
 **/

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
	public GameObject floorStart;

	// RigidBody of player
	public Rigidbody rbPlayer;

	// Player Ref
	public GameObject player;

	// Prefab generated coordinates
	private float xPrePos; // X Axis
	private float yPrePos; // Y Axis
	private float zPrePos; // Z Axis

	// Set endCube, endCubeRotator as global for update()
	private GameObject endCubeRotator = null;
	private GameObject endCube = null;

	// Set light global
	private GameObject endLight = null;
	private Light endLightComp = null;

	// Method that returns the percentage of the distance between the player and the endlight
	float getDistance(float lightPos, float playerPos) {
		return (playerPos * 100) / lightPos;
	}

	// Use this for initialization
	void Start () {

		// Init RigidBody of player
		rbPlayer = player.GetComponent<Rigidbody>();

		// Generate StartCube, EndCube
		GameObject startCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		endCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		endCubeRotator = GameObject.CreatePrimitive(PrimitiveType.Cube);

		// Generate EndCube light
		endLight = new GameObject("EndLight");
		endLightComp = endLight.AddComponent<Light>();

		// Set endLight settings
		endLightComp.type = LightType.Point;
		endLightComp.color = Color.blue;
		endLightComp.intensity = 100.0f;

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

		// Set position of the startCube at origin to catch player
        startCube.transform.position = new Vector3(0, 0, 0);
		// Set position of the endCube, attach to last generated Prefab!
		endCube.transform.position = new Vector3(0, 0, 500.0f);
		// Set Rotator at same x and z coordinates
		endCubeRotator.transform.position = new Vector3(endCube.transform.position.x, (endCube.transform.position.y) + 0.25f, endCube.transform.position.z);
		// Set endLight position
		endLight.transform.position = new Vector3(endCube.transform.position.x, (endCube.transform.position.y) + 5.25f, endCube.transform.position.z);

		// Set name of startCube, endCube
		startCube.name = "StartCube";
		endCube.name = "EndCube";
		endCubeRotator.name = "EndCubeRotator";

		// Check that cubes are not on the same coordinates!
		for(int i = 0; i < 1024; i++) {
			spawnPrefab();
		}

		// Spawn endCube at last prefab!
		// TODO!
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate the endCube Rotator on the y axis
		endCubeRotator.transform.Rotate(new Vector3(0, 40, 0) * Time.deltaTime);

		// Set endLight intensity if player moves
		if(rbPlayer.velocity.magnitude > 0) {
			// Set endLight Intensity
			endLightComp.intensity = getDistance(endLight.transform.position.z, player.transform.position.z);
			// Set Y value of Rotator and set its position
			endCubeRotator.transform.localScale = new Vector3(2.0f, getDistance(endLight.transform.position.z, player.transform.position.z), 2.0f);
			endCubeRotator.transform.position = new Vector3(endCube.transform.position.x, getDistance(endLight.transform.position.z, player.transform.position.z) / 2, endCube.transform.position.z);
		}
	}

	public void spawnPrefab() {
		// Random nr from 1 to 3
		int randNr = Random.Range(0, 3);

		floorStart = (GameObject)Instantiate(floorArray[randNr], floorStart.transform.GetChild(0).transform.GetChild(randNr).position, Quaternion.identity);
	}
}
