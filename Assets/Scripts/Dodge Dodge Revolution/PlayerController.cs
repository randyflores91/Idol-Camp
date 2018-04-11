using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	Animator anim;
	public Transform L1, L5; //Lanes

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ReadyGo.introFinished) {
			if (Input.GetKeyDown (KeyCode.LeftArrow) && transform.position.x > L1.position.x) {
				transform.position = new Vector3 (transform.position.x - 150f, transform.position.y);
				GameLogicDDR.score += 100;
			} else if (Input.GetKeyDown (KeyCode.RightArrow) && transform.position.x < L5.position.x) {
				transform.position = new Vector3 (transform.position.x + 150f, transform.position.y);
				GameLogicDDR.score += 100;
			}
		}

		if (transform.position.x == L5.position.x || transform.position.x == L5.position.x - 150f) {
			transform.rotation = Quaternion.Euler (transform.rotation.x, 180f, 0);
		} else {
			transform.rotation = Quaternion.Euler (transform.rotation.x, 0f, 0);
		}
	}

	void OnTriggerStay(Collider other) {
		anim.SetBool ("Hit", true);
		GameLogicDDR.gainingPoints = false;
	}

	void OnTriggerExit(Collider other)
	{
		anim.SetBool ("Hit", false);
		GameLogicDDR.gainingPoints = true;
	}
}
