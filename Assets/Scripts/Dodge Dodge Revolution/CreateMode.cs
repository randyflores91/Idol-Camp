using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMode : MonoBehaviour {

	public bool createMode;
	public GameObject block;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (createMode) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Instantiate (block, transform.position, transform.rotation, transform);
			}
		}
	}
}
