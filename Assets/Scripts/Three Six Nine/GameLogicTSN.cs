using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicTSN : MonoBehaviour {

	public static int currentNum;
	public GameObject C1, C2, C3, C4, Arrow;
	Player p1, p2, p3, p4;
	bool l1,l2,l3,l4, played;
	int gameEnded;
	AudioSource audio;
	public TransitionScreen TS;

	// Use this for initialization
	void Start () {
		currentNum = 1;
		p1 = C1.GetComponent<Player> ();
		p2 = C2.GetComponent<Player> ();
		p3 = C3.GetComponent<Player> ();
		p4 = C4.GetComponent<Player> ();
		l1 = false;
		l1 = false;
		l1 = false;
		l1 = false;
		played = false;
		gameEnded = 0;
		audio = Arrow.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (p1.gameOver && !l1) {
			gameEnded += 1;
			p1.MissOnly ();
			l1 = true;
		}
		if (p2.gameOver && !l2) {
			gameEnded += 1;
			p2.MissOnly ();
			l2 = true;
		}
		if (p3.gameOver && !l3) {
			gameEnded += 1;
			p3.MissOnly ();
			l3 = true;
		}
		if (p4.gameOver && !l4) {
			gameEnded += 1;
			p4.MissOnly ();
			l4 = true;
		}

		if (gameEnded == 3) {
			p1.turn = false;
			p2.turn = false;
			p3.turn = false;
			p4.turn = false;

			if (!p1.gameOver)
				p1.CorrectOnly ();
			else if (!p2.gameOver)
				p2.CorrectOnly ();
			else if (!p3.gameOver)
				p3.CorrectOnly ();
			else
				p4.CorrectOnly ();
			StartCoroutine("GameEnded");
		}
	}

	public bool Clappable () {
		int temp = currentNum;
		while (temp != 0) {
			int digit = temp % 10;
			if (digit == 3 || digit == 6 || digit == 9) {
				return true;
			}
			temp = temp / 10;
		}
		return false;
	}

	IEnumerator GameEnded () {
		if (!played) {
			audio.Play ();
			played = true;
		}
		yield return new WaitForSeconds (3);
		if (!p1.gameOver)
			StartCoroutine (TS.FadeOut("Win2"));
		else
			StartCoroutine (TS.FadeOut("Lose2"));
	}
}
