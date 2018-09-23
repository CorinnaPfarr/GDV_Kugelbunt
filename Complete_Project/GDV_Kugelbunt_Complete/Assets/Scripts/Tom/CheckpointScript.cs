using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

	// Light
	private GameObject checkLight;
	private Light checkLightComp;

	// Player reference
	public GameObject player;

	// Rigidbody of player
	private Rigidbody rbPlayer;

	// Respawn coordinates
	public Vector3 respawnPos;
	private Vector3 startPos;

	// Active checkpoint bool
	private bool isActive;

	//
	private FloorGenerator floorGenerator;

	// Live amounts
	private int liveNr;

	public List<GameObject> checkPList = new List<GameObject>();

	void OnTriggerEnter(Collider colObj) {
		// Dont render sphere anymore
		gameObject.GetComponent<Renderer>().enabled = false;

		// Set light intensity if player enters collider
		checkLightComp.intensity = 50;

		Debug.Log(floorGenerator.checkPList.Count);

		// Set all checkpoints in list to active = false
		for(int i = 0; i < floorGenerator.checkPList.Count; i++) {
			floorGenerator.checkPList[i].gameObject.transform.GetChild(1).gameObject.GetComponent<CheckpointScript>().isActive = false;
		}

		// Set checkpoint obj position as respawn point
		respawnPos = this.transform.position;
		startPos = respawnPos;

		// Active is true - everyone else is false
		isActive = true;
	}

	// Use this for initialization
	void Start () {
		floorGenerator = GameObject.Find("FloorGenerator").GetComponent<FloorGenerator>();

		// is active false
		isActive = false;

		// Get player object
		player = GameObject.Find("Player");

		// Set Rigidbody of player
		rbPlayer = player.GetComponent<Rigidbody>();

		// Set player respawn vector to (0, 0.8, 0) to avoid no checkpoint entered yet
		// 0.8f on the y axis
		startPos = new Vector3(0.0f, 0.8f, 0.0f);

		// Rotate the Sphere
		transform.Rotate(90f, 90f, 45f);
		// Change Scale
		transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

		// Generate light
		checkLight = new GameObject("checkLight");
		checkLightComp = checkLight.AddComponent<Light>();

		// Set endLight settings
		checkLightComp.type = LightType.Spot;
		checkLightComp.color = Color.white;

		// Set position
		checkLight.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 2.0f, this.transform.position.z);

		// Rotate light
		checkLight.transform.Rotate(90.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// Rotate checkpoint sphere
		transform.Rotate(new Vector3(0, 48, 12) * Time.deltaTime);

		if(player.transform.position.y <= -15) {
			// Decrease lives by 1
			PlayerScript.lives = PlayerScript.lives - 1;
			// lives -1
			liveNr = PlayerScript.lives;

			// respawn player
			player.transform.position = startPos;
			// Set movingSpeed 0
			rbPlayer.velocity = Vector3.zero;
			rbPlayer.angularVelocity = Vector3.zero;
		}


		// Check if player is falling
		if(player.transform.position.y <= -10 && isActive) {
			// Decrease lives by 1
			PlayerScript.lives = PlayerScript.lives - 1;
			// lives -1
			liveNr = PlayerScript.lives;
			


			Debug.Log(startPos);

			// respawn player
			player.transform.position = startPos;
			// Set movingSpeed 0
			rbPlayer.velocity = Vector3.zero;
			rbPlayer.angularVelocity = Vector3.zero;
		}
	}
}