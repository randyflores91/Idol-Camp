using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public AudioSource worldMusic;
	public static bool Paused;
	public TransitionScreen TS;
	// Use this for initialization
	void Start () {
		Paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P) && !Paused) {
			Time.timeScale = 0;
			Paused = true;
			worldMusic.Pause ();
			transform.position = new Vector3 (transform.position.x, transform.position.y+1000);
		}

		else if (Input.GetKeyDown (KeyCode.P) && Paused) {
			transform.position = new Vector3 (transform.position.x, transform.position.y-1000);
			Time.timeScale = 1;
			worldMusic.UnPause ();
			Paused = false;
		}
	}

	public void ReturnToTutorial(string tut) {
		transform.position = new Vector3 (transform.position.x, transform.position.y-1000);
		Time.timeScale = 1;
		worldMusic.UnPause ();
		Paused = false;
		StartCoroutine (TS.FadeOut(tut));
	}

	public void CancelPressed() {
		transform.position = new Vector3 (transform.position.x, transform.position.y-1000);
		Time.timeScale = 1;
		worldMusic.UnPause ();
		Paused = false;
	}
		
}
