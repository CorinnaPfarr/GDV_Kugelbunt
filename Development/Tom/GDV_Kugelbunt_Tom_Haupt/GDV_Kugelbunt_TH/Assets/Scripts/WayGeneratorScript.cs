using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayGeneratorScript : MonoBehaviour {

	// Player instanc to track
	public GameObject player;
	public Material mat;

	// private player position
	private Vector3 playerPos;
	// private player rigidbody
	private Rigidbody playerRig;
	// private count of generated cubes, for win state
	private int genCount;

	// On Collison Enter function (If player is colliding with generated cube)
	void OnCollisionEnter (Collision inObj) {
        if(inObj.gameObject.name == "Player") {
			print("Entered Cube");
        }
    }

	// On Collison Exit function (If player is not colliding with generated cube anymore)
	/*void OnCollisionExit (Collision outObj) {
        Destroy(outObj.gameObject);
    }*/

	// Use this for initialization
	void Start () {
		/** Generate cube underneath player to prevent falling **/
		// Generate cube
		GameObject startCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

		// Set Material of startCube
		startCube.GetComponent<Renderer>().material = mat;

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
	void Update () {
		// Check if player is moving - check velocity
		if(playerRig.velocity.magnitude > 0) {

			print("Moving!");

			// Count generated cubes amount up
			genCount = genCount + 1;
			print(genCount);

			// update player position
			playerPos = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z + 1.0f);

			// Spawn Cube if player moves?
			GameObject genCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			// Set width of generatedWayCube, make width random?
			genCube.transform.localScale = new Vector3(3.0f, 1.0f, 1.0f);

			// Set Material of genCube
			genCube.GetComponent<Renderer>().material = mat;

			// Transform cube to player "path"
			genCube.transform.position = playerPos;

			// Set Name of Cube to handle collision detection
			genCube.name = "genCube#" + genCount;

			// Check if player collides
			//OnCollisionEnter(genCube);
		} else {
			print("Not Moving!");
		}
	}

	// LateUpdate is called once per frame, after Update is finished
	void LateUpdate() {

	}
}
