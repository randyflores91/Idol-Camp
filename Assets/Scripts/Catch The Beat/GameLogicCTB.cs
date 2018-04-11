using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLogicCTB : MonoBehaviour {

	public Transform note1, note2, note3;
	public GameObject helper1, helper2, helper3, helper4, scoreBoardObject;
	public Text disp1, disp2, disp3, scoreBoardText; 
	public static bool hit1, hit2, hit3;
	bool played1, played2, played3, played4, played5;
	public float distance;
	float time;
	int goalBeat1, goalBeat2, goalBeat3;
	public float multiplier;
	float timer;
	AudioSource audio1, audio2, audio3, audio4;
	public static int score;
	public TransitionScreen TS;
	public Animator anim;

	// Use this for initialization
	void Start () {
		// Calculate the bpm
		int t = (int) Random.Range (0f,15f);
		time = 60f / (float)(4 * t + 80);

		timer = 0f;

		// Determines the 
		goalBeat1 = (((int) Random.Range (12f,23f))/4)*4;
		goalBeat2 = (((int) Random.Range (24f,31f))/4)*4;
		goalBeat3 = (((int) Random.Range (32f,43f))/4)*4;

		disp1.text = goalBeat1.ToString();
		disp2.text = goalBeat2.ToString();
		disp3.text = goalBeat3.ToString();

		// This section is for testing purposes
//		goalBeat1 = 12;
//		goalBeat2 = 16;
//		goalBeat3 = 20;
		//

		hit1 = false;
		hit2 = false;
		hit3 = false;
		played1 = false;
		played2 = false;
		played3 = false;
		played4 = false;
		played5 = false;

		audio1 = helper1.GetComponent<AudioSource> ();
		audio2 = helper4.GetComponent<AudioSource> ();
		audio3 = note1.GetComponent<AudioSource> ();
		audio4 = scoreBoardObject.GetComponent<AudioSource> ();

		note1.Translate(new Vector3 (0, distance * goalBeat1 * multiplier));
		note2.Translate(new Vector3 (0, distance * goalBeat2 * multiplier));
		note3.Translate(new Vector3 (0, distance * goalBeat3 * multiplier));

	}
	
	// Update is called once per frame
	void Update () {
		
		if (ReadyGo.introFinished) {
			/*
			Make a condition for when the cakes goes out of bounds hit turns on and allows
			for the player to hit the remaining cakes
		*/
			timer += Time.deltaTime;
			if (!hit1) {
				note1.Translate (Vector3.down * Time.deltaTime * distance / time);
			}
			if (!hit2) {
				note2.Translate (Vector3.down * Time.deltaTime * distance / time);
			}
			if (!hit3) {
				note3.Translate (Vector3.down * Time.deltaTime * distance / time);
			}

			//Turns on helper lights depending on beats/seconds
			if (timer >= time * 1 && timer <= time * 2) {
				if (helper1.activeSelf == false) {
					Debug.Log ("Beat 1 " + timer);
				}
				helper1.SetActive (true);
				if (!played1) {
					audio1.Play ();
					played1 = true;
				}
			}
			if (timer >= time * 2 && timer <= time * 3) {
				if (helper2.activeSelf == false)
					Debug.Log ("Beat 2 " + timer);
				helper2.SetActive (true);
				if (!played2) {
					audio1.Play ();
					played2 = true;
				}
			}
			if (timer >= time * 3 && timer <= time * 4) {
				if (helper3.activeSelf == false)
					Debug.Log ("Beat 3 " + timer);
				helper3.SetActive (true);
				if (!played3) {
					audio1.Play ();
					played3 = true;
				}
			}
			if (timer >= time * 4 && timer <= time * 5) {
				if (helper4.activeSelf == false)
					Debug.Log ("Beat 4 " + timer);
				helper4.SetActive (true);
				if (!played4) {
					audio2.Play ();
					played4 = true;
				}
			}
			if (timer >= time * 5 && timer <= time * 6) {
				if (helper4.activeSelf == true)
					Debug.Log ("Beat 5 " + timer);
				helper2.SetActive (false);
				helper3.SetActive (false);
				helper4.SetActive (false);
				if (played4) {
					audio1.Play ();
					played2 = false;
					played3 = false;
					played4 = false;
				}
			}
			if (timer >= time * 6 && timer <= time * 7) {
				if (helper2.activeSelf == false)
					Debug.Log ("Beat 6 " + timer);
				helper2.SetActive (true);
				if (!played2) {
					audio1.Play ();
					played2 = true;
				}
			}
			if (timer >= time * 7 && timer <= time * 8) {
				if (helper3.activeSelf == false)
					Debug.Log ("Beat 7 " + timer);
				helper3.SetActive (true);
				if (!played3) {
					audio1.Play ();
					played3 = true;
				}
			}
			if (timer >= time * 8 && timer <= time * 9) {
				if (helper4.activeSelf == false)
					Debug.Log ("Beat 8 " + timer);
				helper4.SetActive (true);
				if (!played4) {
					audio2.Play ();
					played4 = true;
				}
			}

			if (timer >= time * 8 && Input.GetKeyDown (KeyCode.Space) && !hit1) {
				hit1 = true;
				audio3.Play ();
				anim.SetTrigger ("Hit");
				anim.SetTrigger ("JumpOver");
			} else if (timer >= time * 8 && Input.GetKeyDown (KeyCode.Space) && hit1 && !hit2) {
				hit2 = true;
				audio3.Play ();
				anim.SetTrigger ("Hit");
				anim.SetTrigger ("JumpOver");
			} else if (timer >= time * 8 && Input.GetKeyDown (KeyCode.Space) && hit1 && hit2 && !hit3) {
				hit3 = true;
				audio3.Play ();
				anim.SetTrigger ("Hit");
				anim.SetTrigger ("JumpOver");
			}

			if (timer >= time * (goalBeat1 + 2f) && !hit1) {
				hit1 = true;
			} else if (timer >= time * (goalBeat2 + 2f) && hit1 && !hit2) {
				hit2 = true;
			} else if (timer >= time * (goalBeat3 + 2f) && hit1 && hit2 && !hit3) {
				hit3 = true;
			}


			if (hit1 && hit2 && hit3) {
				float score1, score2, score3;
				float total = 999999f / 3f;
				float length = 500f;

				if (note1.position.y > note1.parent.position.y+500 || note1.position.y < note1.parent.position.y-500) {
					score1 = 0;
				} else {
					score1 = total - ((Mathf.Abs (note1.position.y - note1.parent.position.y) / length) * total);
					Debug.Log ("Score1: " + note1.position.y + " " + score1);
				}
				if (note2.position.y > note2.parent.position.y+500 || note2.position.y < note2.parent.position.y-500) {
					score2 = 0;
				} else {
					score2 = total - ((Mathf.Abs (note2.position.y - note2.parent.position.y) / length) * total);
					Debug.Log ("Score2: " + note2.position.y + " " + score2);
				}
				if (note3.position.y > note3.parent.position.y+500 || note3.position.y < note3.parent.position.y-500) {
					score3 = 0;
				} else {
					score3 = total - ((Mathf.Abs (note3.position.y - note3.parent.position.y) / length) * total);
					Debug.Log ("Score3: " + note3.position.y + " " + score3);
				}

				score = (int)(score1 + score2 + score3);
				Debug.Log ("Score: " + score);
				scoreBoardText.text = score.ToString ();
				anim.SetTrigger ("Hit");

				StartCoroutine ("GameEnded");
			}
		}

	}

	IEnumerator GameEnded () {
		if (!played5) {
			audio4.Play ();
			played5 = true;
		}
		yield return new WaitForSeconds (3);
		if (score > 400000) {
			//score = 0;
			StartCoroutine (TS.FadeOut ("Win1"));
		} else {
			//score = 0;
			StartCoroutine (TS.FadeOut ("Lose1"));
		}
	}
}
