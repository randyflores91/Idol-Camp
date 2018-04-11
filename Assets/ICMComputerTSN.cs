using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICMComputerTSN : MonoBehaviour {

	ICMPlayerTSN playerObject;
	public bool madeInput;
	int i = 0;

	// Use this for initialization
	void Start () {
		playerObject = GetComponent<ICMPlayerTSN> ();
		madeInput = false;
	}

	// Update is called once per frame
	void Update () {
		if (ICMGameLogicTSN.ComputersCanPlay && (playerObject.turn) && ICMGameLogicTSN.timer <= ICMGameLogicTSN.time * 15) {

			if (!madeInput) {
					madeInput = true;

						playerObject.StartCoroutine (NumOrClap ());
				}

			} else {
				madeInput = false;
			}
	}

	string NumOrClap() {
		string s = "SpaceHit";
		string u = "UpHit";
		bool clap = playerObject.World.Clappable ();

			if (clap == true)
				return s;
			else
				return u;
		 
	}
}
