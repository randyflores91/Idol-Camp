using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicICM : MonoBehaviour {

	public static float time, beat;
	public float beatPublic, timePublic;
	public static int score;
	public Text scoreText;
	public GameObject yellowScore, whiteScore;
	AudioSource audioWin;
	public GameObject G1, G2, G3, G4, G5, G6, G7;
	public TransitionScreen TS;
	public static bool ICM = false;

	// Use this for initialization
	void Start () {
		score = 0;
		time = 0;
		beat = 0;

		ICM = true;
		yellowScore.SetActive (false);
		audioWin = whiteScore.GetComponent<AudioSource> ();
		G7.SetActive (true);
		G7.GetComponent<Canvas> ().sortingOrder = 5;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		beat = time / (60f/132f);
		beatPublic = beat;
		timePublic = time;


		if (score >= 0)
			scoreText.text = score.ToString ();
		else {
			score = 0;
			scoreText.text = "0";
		}

		if (beat > 32.5 && beat <= 33) {
			G1.SetActive (false);
		} else if (beat > 33 && beat <= 34) {
			G2.SetActive (true);
		} else if (beat > 66.5 && beat < 67) {
			G2.SetActive (false);
		} else if (beat > 67 && beat <= 68) {
			G3.SetActive (true);
		} else if (beat > 80.5 && beat < 81) {
			G3.SetActive (false);
		} else if (beat > 81 && beat <= 82) {
			G4.SetActive (true);
		} else if (beat > 96.5 && beat < 97) {
			G4.SetActive (false);
		} else if (beat >= 97 && beat < 98) {
			G5.SetActive (true);
		} else if (beat > 130 && beat < 131) {
			G5.SetActive (false);
		} else if (beat >= 131 && beat < 132) {
			G6.SetActive (true);
		} else if (beat > 164 && beat < 169) {
			yellowScore.SetActive (true);
			StartCoroutine (GameEnded());
		}
	}

	IEnumerator GameEnded () {
		audioWin.Play ();
		yield return new WaitForSeconds (3);
		if (score > 400000) {
			//score = 0;
			StartCoroutine (TS.FadeOut ("Win5"));
		} else {
			//score = 0;
			StartCoroutine (TS.FadeOut ("Lose5"));
		}
	}
}
