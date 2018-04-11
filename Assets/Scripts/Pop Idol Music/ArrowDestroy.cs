using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour {

	float time;
	//public GameObject last;
	public static int counter;

	// Use this for initialization
	void Start () {
		time = 0;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (counter == 5) {
			GameLogicPIM.Miss ();
			counter = 0;
		}
	}

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
		GameLogicPIM.score -= 50;
		counter += 1;
//		if (other.name == last.name)
//			Debug.Log ("last object crossed at "+time);
	}
}
