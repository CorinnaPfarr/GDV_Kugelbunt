using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSpawnerScript : MonoBehaviour {

	public GameObject checkPointPrefab;
	private CheckpointScript script;

	private List<GameObject> spawnList;

	// Use this for initialization
	void Start () {
		GameObject checkpoint = (GameObject)Instantiate(checkPointPrefab, checkPointPrefab.transform.position, checkPointPrefab.transform.rotation);
		// Spawn at Start, set position in editor.
		checkpoint.transform.position = new Vector3(0, 0, 0);
		script = (CheckpointScript)checkpoint.GetComponent<CheckpointScript>();

		// Get the respawn list
		script.respawnPos = checkpoint.transform.position;
		// Add to list
		spawnList.Add(checkpoint);

		checkpoint = (GameObject)Instantiate(checkPointPrefab, checkPointPrefab.transform.position, checkPointPrefab.transform.rotation);
		// Spawn at Start, set position in editor.
		checkpoint.transform.position = new Vector3(0, 0, 0);
		script = (CheckpointScript)checkpoint.GetComponent<CheckpointScript>();

		// Get the respawn list
		script.respawnPos = checkpoint.transform.position;
		// Add to list
		spawnList.Add(checkpoint);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
