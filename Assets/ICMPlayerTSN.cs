using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ICMPlayerTSN : MonoBehaviour {

	public bool turn = false;
	public bool gameOver = false;
	public ICMPlayerTSN nextPlayer;
	public GameObject xMark, clap, numberText, Grid;
	public ICMGameLogicTSN World;
	public Text num;
	float wait = 60f/132f;
	float wait2 = 60f/132f;
	AudioSource audioWrong, audioRight, audioSlap;
	public Animator anim;



	// Use this for initialization
	void Start () {
		SetGridInactive ();
		World = World.GetComponent<ICMGameLogicTSN> ();
		audioWrong = xMark.GetComponent<AudioSource> ();
		audioRight = Grid.GetComponent<AudioSource> ();
		audioSlap = clap.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetGridInactive () {
		xMark.SetActive (false);
		clap.SetActive (false);
		numberText.SetActive (true);
		num.text = "?"; 
	}

//	public void Mistake	() {
//		if (fault1.activeSelf) {
//			fault2.SetActive (true);
//			gameOver = true;
//		}
//		else {
//			fault1.SetActive (true);
//		}
//	}


	IEnumerator SpaceHit() {
		//Debug.Log (this.name+" "+ICMGameLogicTSN.currentNum.ToString ());
		SetGridInactive ();
		numberText.SetActive (false);
		clap.SetActive (true);
		audioSlap.Play ();
		//yield return new WaitForSeconds(wait2);
		//		clap.SetActive (false);
		if (World.Clappable () == true) {
			//			oMark.SetActive (true);
			audioRight.Play ();
			Correct ();
			ICMGameLogicTSN.currentNum++;
		}
		else {
			clap.SetActive (false);
			xMark.SetActive (true);
			audioWrong.Play ();
			Miss ();
			//Mistake ();
			ICMGameLogicTSN.currentNum++;
		}

		yield return new WaitForSeconds(wait);
		SetGridInactive ();
		turn = false;
		nextPlayer.turn = true;
	}

	IEnumerator UpHit() {
		//Debug.Log (this.name+" "+ICMGameLogicTSN.currentNum.ToString ());
		SetGridInactive ();
		num.text = ICMGameLogicTSN.currentNum.ToString();
		//yield return new WaitForSeconds(wait2);
		//		numberText.SetActive (false);
		if (World.Clappable () == false) {
			//			oMark.SetActive (true);
			audioRight.Play ();
			Correct ();
			ICMGameLogicTSN.currentNum++;
		}
		else {
			xMark.SetActive (true);
			audioWrong.Play ();
			Miss ();
			//Mistake ();
			ICMGameLogicTSN.currentNum++;
		}

		yield return new WaitForSeconds(wait);
		SetGridInactive ();
		turn = false;
		nextPlayer.turn = true;
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
