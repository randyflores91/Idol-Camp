using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollider : MonoBehaviour {

	bool currentlyColliding;
	public GameObject litArrow;

	// Use this for initialization
	void Start () {
		currentlyColliding = false;
		litArrow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (!currentlyColliding) {
			if (transform.name == "Left" && Input.GetKeyDown (KeyCode.LeftArrow)) {
				currentlyColliding = true;
				StartCoroutine("LightArrow");
				addPoints (other.transform.position.x);
				Destroy (other.gameObject);
			} else if (transform.name == "Up" && Input.GetKeyDown (KeyCode.UpArrow)) {
				currentlyColliding = true;
				StartCoroutine("LightArrow");
				addPoints (other.transform.position.x);
				Destroy (other.gameObject);
			} else if (transform.name == "Down" && Input.GetKeyDown (KeyCode.DownArrow)) {
				currentlyColliding = true;
				StartCoroutine("LightArrow");
				addPoints (other.transform.position.x);
				Destroy (other.gameObject);
			} else if (transform.name == "Right" && Input.GetKeyDown (KeyCode.RightArrow)) {
				currentlyColliding = true;
				StartCoroutine("LightArrow");
				addPoints (other.transform.position.x);
				Destroy (other.gameObject);
			}
		}
		currentlyColliding = false;
	}

	void OnTriggerEnter(Collider other) {
		if (!currentlyColliding) {
			if (other.name == "LastDrum") {
				GameLogicPIM.Sing ();
			}
				
			if (transform.name == "Left" && Input.GetKeyDown (KeyCode.LeftArrow)) {
				currentlyColliding = true;
				StartCoroutine("LightArrow");
				addPoints (other.transform.position.x);
				Destroy (other.gameObject);
			} else if (transform.name == "Up" && Input.GetKeyDown (KeyCode.UpArrow)) {
				currentlyColliding = true;
				StartCoroutine("LightArrow");
				addPoints (other.transform.position.x);
				Destroy (other.gameObject);
			} else if (transform.name == "Down" && Input.GetKeyDown (KeyCode.DownArrow)) {
				currentlyColliding = true;
				StartCoroutine("LightArrow");
				addPoints (other.transform.position.x);
				Destroy (other.gameObject);
			} else if (transform.name == "Right" && Input.GetKeyDown (KeyCode.RightArrow)) {
				currentlyColliding = true;
				StartCoroutine("LightArrow");
				addPoints (other.transform.position.x);
				Destroy (other.gameObject);
			}
		}
		currentlyColliding = false;
	}

	void addPoints (float xPos) {
		if (Mathf.Abs(xPos-this.transform.position.x) <= 25f) {
			GameLogicPIM.score += 1000;
			GameLogicICM.score += 5000;
			//Debug.Log (xPos + " was Perfect");
		} else {
			GameLogicPIM.score += 500;
			GameLogicICM.score += 3000;
			//Debug.Log (xPos + " was Good");
		}

		GameLogicPIM.Hit ();
	}

	IEnumerator LightArrow() {
		litArrow.SetActive (true);
		yield return new WaitForSeconds (10f / 60f);
		litArrow.SetActive (false);
	}
}
