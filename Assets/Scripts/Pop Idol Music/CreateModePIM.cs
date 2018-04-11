using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateModePIM : MonoBehaviour {

	public bool createMode;
	public GameObject arrow;
	float timer;
	public static float beat;
	public static float time;
	public float sec;

	// Use this for initialization
	void Start () {
		timer = 0;
		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void Update () {
		timer += (Time.deltaTime);
		if (createMode) {
			if (Input.GetKeyDown (KeyCode.M)) {
				time = timer;
				beat = timer / sec;
				Instantiate (arrow, transform.position, transform.rotation, transform);
			}
		}
	}
}
