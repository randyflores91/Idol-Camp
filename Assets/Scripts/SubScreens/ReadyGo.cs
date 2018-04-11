using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyGo : MonoBehaviour {

	public GameObject ready, go, readySound, goSound;
	public 
	float time;
	public static bool introFinished;

	// Use this for initialization
	void Start () {
		time = 0;
		introFinished = false;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time >= 0.0f)
			ready.SetActive (true);
		if (time >= 0.7f)
			readySound.SetActive (true);
		if (time >= 1.9f)
			go.SetActive (true);
		if (time >= 1.9f + 10f / 60f)
			goSound.SetActive (true);
		if (time >= 3f)
			introFinished = true;
	}
}
