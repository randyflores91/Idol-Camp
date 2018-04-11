using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("Something collided");
		if (other.tag == "Cake") {
			//Debug.Log ("Out of Bound 1");
			GameLogicCTB.hit1 = true;
		}
		if (other.name == "Cake2") {
			GameLogicCTB.hit2 = true;
		}
		if (other.name == "Cake3") {
			GameLogicCTB.hit3 = true;
		}
	}
}
