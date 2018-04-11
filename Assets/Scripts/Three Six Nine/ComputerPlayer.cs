using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour {

	Player playerObject;
	public bool madeInput;
//	public GameLogicTSN world;

	// Use this for initialization
	void Start () {
		playerObject = GetComponent<Player> ();
//		world = GetComponent<GameLogicTSN> ();
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

				if (!madeInput) {
					madeInput = true;
					playerObject.StartCoroutine (NumOrClap ());
				}

			} else {
				madeInput = false;
			}
		}
	}

	string NumOrClap() {
		string s = "SpaceHit";
		string u = "UpHit";
		int prob = Random.Range (0, 100);
		bool clap = playerObject.World.Clappable ();
		 
		if (GameLogicTSN.currentNum <= 10) {
			if (clap == true)
				return s;
			else
				return u;
		}

		else if (GameLogicTSN.currentNum <= 20){
			if (prob < 90) {
				if (clap == true)
					return s;
				else
					return u;
			} else {
				if (clap == true)
					return u;
				else
					return s;
			}
		}

		else if (GameLogicTSN.currentNum <= 30){
			if (prob < 80) {
				if (clap == true)
					return s;
				else
					return u;
			} else {
				if (clap == true)
					return u;
				else
					return s;
			}
		}

		else if (GameLogicTSN.currentNum <= 45){
			if (prob < 60) {
				if (clap == true)
					return s;
				else
					return u;
			} else {
				if (clap == true)
					return u;
				else
					return s;
			}
		}

		else if (GameLogicTSN.currentNum <= 60){
			if (prob < 50) {
				if (clap == true)
					return s;
				else
					return u;
			} else {
				if (clap == true)
					return u;
				else
					return s;
			}
		}

		else {
			if (prob < 30) {
				if (clap == true)
					return s;
				else
					return u;
			} else {
				if (clap == true)
					return u;
				else
					return s;
			}
		}
	}
}
