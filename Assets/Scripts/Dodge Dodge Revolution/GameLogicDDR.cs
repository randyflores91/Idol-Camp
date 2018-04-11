using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogicDDR : MonoBehaviour {

	public Text scoreText;
	public static int score;
	public static bool gainingPoints;
	float timer;
	float x;
	public TransitionScreen TS;

	// Use this for initialization
	void Start () {
		score = 0;
		gainingPoints = true;
		timer = 0;
		x = 899999 / 130;
	}
	
	// Update is called once per frame
	void Update () {
		if (ReadyGo.introFinished) {
			timer += Time.deltaTime;
//		Debug.Log("time: "+timer);
			if (gainingPoints) {
				score += (int)(x * Time.deltaTime);
				GameLogicICM.score += (int)((x-2000) * Time.deltaTime);
			} else if (!gainingPoints && timer <= 130f) {
				score -= (int)(x * Time.deltaTime);
				GameLogicICM.score -= (int)((x-2000) * Time.deltaTime);
			}

			if (score >= 0)
				scoreText.text = score.ToString ();
			else {
				score = 0;
				scoreText.text = "0";
			}

			if (timer >= 130f) {
				Debug.Log ("score: " + score);
				gainingPoints = false;
				StartCoroutine ("GameEnded");
			}
		}
			
	}

	IEnumerator GameEnded () {
//		if (!played5) {
//			audio4.Play ();
//			played5 = true;
//		}
		yield return new WaitForSeconds (3);
		if (score > 700000) {
			//score = 0;
			StartCoroutine (TS.FadeOut ("Win3"));
		} else {
			//score = 0;
			StartCoroutine (TS.FadeOut ("Lose3"));
		}
	}
}
