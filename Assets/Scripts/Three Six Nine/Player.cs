using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public bool turn = false;
	public bool gameOver = false;
	public Player nextPlayer;
	public GameObject xMark, oMark, clap, numberText, fault1, fault2, Grid;
	public GameLogicTSN World;
	public Text num;
	float wait = 1f;
	float wait2 = 0.3f;
	AudioSource audioWrong, audioRight, audioSlap;
	public Animator anim;



	// Use this for initialization
	void Start () {
		fault1.SetActive (false);
		fault1.SetActive (false);
		SetGridInactive ();
		World = World.GetComponent<GameLogicTSN> ();
		audioWrong = xMark.GetComponent<AudioSource> ();
		audioRight = Grid.GetComponent<AudioSource> ();
		audioSlap = clap.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetGridInactive () {
		xMark.SetActive (false);
		oMark.SetActive (false);
		clap.SetActive (false);
		numberText.SetActive (true);
		num.text = "?"; 
	}

	public void Mistake	() {
		if (fault1.activeSelf) {
			fault2.SetActive (true);
			gameOver = true;
		}
		else {
			fault1.SetActive (true);
		}
	}
		

//	public IEnumerator KeyHit(KeyCode k) {
//		Debug.Log ("Entered KeyHit Function");
//		SetGridInactive ();
//
//		if (k == KeyCode.Space) {
//			numberText.SetActive (false);
//			clap.SetActive (true);
//		} else {
//			num.text = GameLogicTSN.currentNum.ToString(); 
//		}
//
//		Debug.Log ("About to wait a Second");
//		yield return new WaitForSeconds(1f); 
//		Debug.Log ("Waited a Second");
//
//		clap.SetActive (false);
//		numberText.SetActive (false);
//
//		if ((World.Clappable () == true && k == KeyCode.Space) || 
//			(World.Clappable () == false && k == KeyCode.UpArrow)) {
//			Debug.Log ("About to Say it was correct");
//			oMark.SetActive (true);
//		}
//		else {
//			xMark.SetActive (true);
//			Mistake ();
//		}
//
//
//		Debug.Log ("About to wait a 2nd Second");
//		yield return new WaitForSeconds(1f); 
//		Debug.Log ("Waited a 2nd Second");
//
//		SetGridInactive ();
//		turn = false;
//		nextPlayer.turn = true;
//	}

	IEnumerator SpaceHit() {
		SetGridInactive ();
		numberText.SetActive (false);
		clap.SetActive (true);
		audioSlap.Play ();
		yield return new WaitForSeconds(wait2);
//		clap.SetActive (false);
		if (World.Clappable () == true) {
//			oMark.SetActive (true);
			audioRight.Play ();
			Correct ();
			GameLogicTSN.currentNum += 1;
		}
		else {
			clap.SetActive (false);
			xMark.SetActive (true);
			audioWrong.Play ();
			Miss ();
			Mistake ();
			GameLogicTSN.currentNum += 1;
		}

		yield return new WaitForSeconds(wait);
		SetGridInactive ();
		turn = false;
		nextPlayer.turn = true;
	}

	IEnumerator UpHit() {
		SetGridInactive ();
		num.text = GameLogicTSN.currentNum.ToString();
		yield return new WaitForSeconds(wait2);
//		numberText.SetActive (false);
		if (World.Clappable () == false) {
//			oMark.SetActive (true);
			audioRight.Play ();
			Correct ();
			GameLogicTSN.currentNum += 1;
		}
		else {
			xMark.SetActive (true);
			audioWrong.Play ();
			Miss ();
			Mistake ();
			GameLogicTSN.currentNum += 1;
		}

		yield return new WaitForSeconds(wait);
		SetGridInactive ();
		turn = false;
		nextPlayer.turn = true;
	}

	IEnumerator WaitHalfSec ()
	{ 
		yield return new WaitForSeconds(5f); 
		Debug.Log ("Finished Waiting");
	}

	public void Correct() {
		anim.SetTrigger ("Correct");
		anim.SetTrigger ("Default");
	}

	public void Miss() {
		anim.SetTrigger ("Miss");
		anim.SetTrigger ("Default");
	}

	public void CorrectOnly() {
		anim.SetTrigger ("Correct");
	}

	public void MissOnly() {
		anim.SetTrigger ("Miss");
	}
}
