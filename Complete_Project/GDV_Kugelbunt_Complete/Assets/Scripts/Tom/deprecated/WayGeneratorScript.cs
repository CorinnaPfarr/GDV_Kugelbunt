using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayGeneratorScript : MonoBehaviour {

	// Player instanc to track
	public GameObject player;
	public Material mat;
	public GameObject prefab;

	// private player position
	private Vector3 playerPos;
	// private player rigidbody
	private Rigidbody playerRig;
	// private count of generated cubes, for win state
	private int genCount;

	// Use this for initialization
	void Start() {
		/** Generate cube underneath player to prevent falling **/
		// Generate cube
		GameObject startCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		// Set Material of startCube
		startCube.GetComponent<Renderer>().material = mat;

		// Set StartCube Size
		startCube.transform.localScale = new Vector3(4.0f, 0.5f, 4.0f);

		// Set position of the cube at origin to catch player
        startCube.transform.position = new Vector3(0, 0, 0);

		// Set name of start cube
		startCube.name = "StartCube";

		// Get RigidBody of player
		playerRig = player.GetComponent<Rigidbody>();

		// Set generated cube count to 0
		genCount = 0;
	}
	
	// Update is called once per frame
	void Update() {
		// Check if player is moving - check velocity
		if(playerRig.velocity.magnitude > 0) {

			// Count generated cubes amount up
			genCount = genCount + 1;
			//print(genCount);

			// update player position
			playerPos = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z + 1.0f);

			// Spawn Cube if player moves? Use prefab
			GameObject genCube = (GameObject)Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
			//GameObject.CreatePrimitive(PrimitiveType.Cube);
			// Set width of generatedWayCube, make width random?
			//genCube.transform.localScale = new Vector3(3.0f, 0.5f, 1.0f);

			// Set Material of genCube
			//genCube.GetComponent<Renderer>().material = mat;

			// Transform cube to player "path"
			genCube.transform.position = playerPos;

			// Set Name of Cube to handle collision detection
			genCube.name = "genCube#" + genCount;

			// Check if player collides
			
		} else {
			//print("Not Moving!");
		}
	}

	// LateUpdate is called once per frame, after Update is finished
	void LateUpdate() {

	}

	void OnCollisionEnter(Collision colObj) {

		Debug.Log(colObj);

		if(colObj.gameObject.name == "Player") {
			Debug.Log("Player entered!");
		}
	}

	void OnCollisionExit(Collision colObj) {
		if(colObj.gameObject.name == "Player") {
			Debug.Log("Player exited!");
		}
	}
}