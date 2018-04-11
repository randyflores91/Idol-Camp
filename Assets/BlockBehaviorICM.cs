using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviorICM : MonoBehaviour {

	public float distance;
	public float time;

	// Use this for initialization
	void Start () {
		//transform.position = new Vector3 (transform.position.x, transform.position.y * 3);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * Time.deltaTime * (distance) / time);
	}
}
