using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIScript : MonoBehaviour {

	// Time text
	public Text timerText;
	// Lives text
	public Text liveText;
	private float start;
	private float end;
	// Text for Minutes, seconds
	private string minutes;
	private string seconds;
	private int liveNr;

	// seconds that can be decreased
	public static float realSec;

	// get seconds
	public static float getSeconds() {
		return realSec;
	}

	// Use this for initialization
	void Start () {
		// Start is actual time
		start = Time.time;
		// Set amount of lives
		liveNr = PlayerScript.lives;
	}
	
	// Update is called once per frame
	void Update () {
		// Calc - update Time
		realSec = Time.time - start;

		// Temp var
		//realSec = end;

		//Debug.Log("TIME: " + realSec);

		// Check for live changes
		liveNr = PlayerScript.lives;

		// calc time.
		minutes = ((int) end / 60).ToString();
		seconds = ((int) getSeconds() % 60).ToString("f0"); // zero decimals

		// Set Time String (UI)
		timerText.text = "Time: " + minutes + ":" + seconds;

		// Set Lives String (UI)
		liveText.text = "Lives: " + liveNr;
	}
}