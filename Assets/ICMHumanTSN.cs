using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICMHumanTSN : MonoBehaviour {

	ICMPlayerTSN playerObject;
	public bool madeInput;

	// Use this for initialization
	void Start () {
		playerObject = GetComponent<ICMPlayerTSN> ();
		madeInput = false;
	}

	// Update is called once per frame
	void Update () {
		if (playerObject.turn && ((ICMGameLogicTSN.timer >= ICMGameLogicTSN.time * 10
			&& ICMGameLogicTSN.timer <= ICMGameLogicTSN.time * 11) || 
			(ICMGameLogicTSN.timer >= ICMGameLogicTSN.time * 14
				&& ICMGameLogicTSN.timer <= ICMGameLogicTSN.time * 15.5))) {

				if (!madeInput && (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space))) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
						playerObject.StartCoroutine ("UpHit");
						
					} else {
						
						playerObject.StartCoroutine ("SpaceHit");
					GameLogicICM.score += 50000;
					}
					madeInput = true;
				}
			} 
		else if (playerObject.turn && ICMGameLogicTSN.timer >= ICMGameLogicTSN.time * 11) {
			playerObject.turn = false;
			playerObject.nextPlayer.turn = true;
			//ICMGameLogicTSN.currentNum++;
		}
		else {
			madeInput = false;
		}

	}
}
