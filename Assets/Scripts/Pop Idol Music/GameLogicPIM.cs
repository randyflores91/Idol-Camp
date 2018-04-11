using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogicPIM : MonoBehaviour {

	public static int score;
	public GameObject yellowScore, whiteScore, character;
	public Text scoreText;
	float time;
	AudioSource audioWin;
	public TransitionScreen TS;
	public static Animator anim;
	bool x = false;


	// Use this for initialization
	void Start () {
		score = 0;
		if (GameLogicICM.ICM)
			score = GameLogicICM.score;
		time = 0;
		yellowScore.SetActive (false);
		audioWin = whiteScore.GetComponent<AudioSource> ();
		anim = character.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ReadyGo.introFinished && !x) {
			Dance ();
			x = true;
		}

		time += Time.deltaTime;

		if (score >= 0)
			scoreText.text = score.ToString ();
		else {
			score = 0;
			scoreText.text = "0";
		}

		if (time >= 117f) {
			anim.SetTrigger ("Default");
			Dance ();
			yellowScore.SetActive (true);
			StartCoroutine ("GameEnded");
		}
	}

	IEnumerator GameEnded () {
		audioWin.Play ();
		yield return new WaitForSeconds (3);
		if (score > 100000) {
			//score = 0;
			StartCoroutine (TS.FadeOut ("Win4"));
		} else {
			//score = 0;
			StartCoroutine (TS.FadeOut ("Lose4"));
		}
	}

	public static void Hit() {
		anim.SetTrigger ("Hit");
		ArrowDestroy.counter = 0;
		anim.SetTrigger ("Default");
	}

	public static void Miss() {
		anim.SetTrigger ("Miss");
		anim.SetTrigger ("Default");
	}

	public static void Dance() {
		anim.SetBool ("Dance", true);
	}

	public static void Sing() {
		anim.SetBool ("Dance", false);
	}
}
