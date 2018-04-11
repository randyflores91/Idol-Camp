using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : MonoBehaviour {

	float time;
	// Use this for initialization
	void Start () {
		time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log (time);
		other.enabled = false;
	}
}
