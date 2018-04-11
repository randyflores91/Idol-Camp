using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour {

	Player playerObject;
	public bool madeInput;

	// Use this for initialization
	void Start () {
		playerObject = GetComponent<Player> ();
		madeInput = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ReadyGo.introFinished) {
			if (playerObject.turn) {
				if (playerObject.gameOver && !madeInput) {
					playerObject.turn = false;
					playerObject.nextPlayer.turn = true;
					return;
				}

				Debug.Log ("It's " + name + " turn!");
		
				if (!madeInput && (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space))) {
					if (Input.GetKeyDown (KeyCode.UpArrow)) {
						Debug.Log ("I hit the up arrow");
						playerObject.StartCoroutine ("UpHit");
						Debug.Log ("Finished");
					} else {
						Debug.Log ("I hit the up arrow");
						playerObject.StartCoroutine ("SpaceHit");
						Debug.Log ("Finished");
					}
					madeInput = true;
				}
			} else {
				madeInput = false;
			}
		}
	}
}
