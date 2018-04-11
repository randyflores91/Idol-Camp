using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ICMGameLogicTSN : MonoBehaviour {

	public static int currentNum;
	public GameObject helper1, helper2, helper3, helper4;
	public Text disp;
	bool played1, played2, played3, played4, played5;
	public static float time;
	public static float timer, beatTimer;
	AudioSource audio1, audio2;
	public static bool ComputersCanPlay = false;

	// Use this for initialization
	void Start () {
		currentNum = 2;
		time = 60f / 132f;

		timer = 0;
		beatTimer = GameLogicICM.beat;
		ComputersCanPlay = false;

		played1 = false;
		played2 = false;
		played3 = false;
		played4 = false;
		played5 = false;

		audio1 = helper1.GetComponent<AudioSource> ();
		audio2 = helper4.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		disp.text = currentNum.ToString ();

		if (timer >= time * 3 && timer <= time * 4) {
			helper1.SetActive (true);
			if (!played1) {
				currentNum += 1;
				audio1.Play ();
				played1 = true;
			}
		}
		if (timer >= time * 4 && timer <= time * 5) {
			
			helper2.SetActive (true);
			if (!played2) {
				currentNum += 1;
				audio1.Play ();
				played2 = true;
			}
		}
		if (timer >= time * 5 && timer <= time * 6) {
			
			helper3.SetActive (true);
			if (!played3) {
				currentNum += 1;
				audio1.Play ();
				played3 = true;
			}

		}
		if (timer >= time * 6 && timer <= time * 7) {
			helper4.SetActive (true);
			if (!played4) {
				currentNum += 1;
				audio2.Play ();
				played4 = true;
			}

		}

		if (timer >= time * 7 && timer <= time * 8) {
			if (!played5) {
				ComputersCanPlay = true;
				played5 = true;
			}
		}
	}

	public bool Clappable () {
		int temp = currentNum;
		while (temp != 0) {
			//currentNum += 1;
			int digit = temp % 10;
			if (digit == 3 || digit == 6 || digit == 9) {
				return true;
			}
			temp = temp / 10;
		}
		return false;
	}

//	IEnumerator GameEnded () {
//		if (!played) {
//			audio.Play ();
//			played = true;
//		}
//		yield return new WaitForSeconds (3);
//		if (!p1.gameOver)
//			StartCoroutine (TS.FadeOut("Win2"));
//		else
//			StartCoroutine (TS.FadeOut("Lose2"));
//	}
}
