using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void PlayGame() {
		// Load next Scene/Level
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ExitGame() {
		Debug.Log("EXITED GAME!");
		Application.Quit();
	}

}
