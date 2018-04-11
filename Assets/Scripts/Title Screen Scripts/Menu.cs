using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public Image startMenu;
	public Image quitMenu;
	public Image jumpMenu;
	public Button play;
	public Button quit;
	public Button start, cancel, yes, no;
	public TransitionScreen TS;

	// Use this for initialization
	void Start () {
		startMenu = startMenu.GetComponent<Image> ();
		quitMenu = quitMenu.GetComponent<Image> ();
		play = play.GetComponent<Button> ();
		quit = quit.GetComponent<Button> ();
		start = start.GetComponent<Button> ();
		cancel = cancel.GetComponent<Button> ();
		yes = yes.GetComponent<Button> ();
		no = no.GetComponent<Button> ();

//		DeactivateQuit ();
//		DeactivateStart ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPressed() {
		play.enabled = false;
		quit.enabled = false;
	}

	public void Activate() {
		play.enabled = true;
		quit.enabled = true;
	}

//	void ActivateStart() {
//		startMenu.enabled = true;
//		start.enabled = true;
//		cancel.enabled = true;
//	}
//
//	void DeactivateStart() {
//		quitMenu.enabled = false;
//		yes.enabled = false;
//		no.enabled = false;
//	}
//
//	void ActivateQuit() {
//		quitMenu.enabled = true;
//		yes.enabled = true;
//		no.enabled = true;
//	}
//
//	void DeactivateQuit() {
//		startMenu.enabled = false;
//		start.enabled = false;
//		cancel.enabled = false;
//	}


	public void PlayPressed() {
		startMenu.rectTransform.position = new Vector3(startMenu.rectTransform.position.x, 
			startMenu.rectTransform.position.y+1000);
//		ActivateStart ();
		ButtonPressed ();
	}

	public void QuitPressed() {
		quitMenu.rectTransform.position = new Vector3(quitMenu.rectTransform.position.x, 
			quitMenu.rectTransform.position.y+1000);
//		ActivateQuit ();
		ButtonPressed ();
	}
		

	public void StartGame(string firstTutScene) {
		startMenu.rectTransform.position = new Vector3(startMenu.rectTransform.position.x, 
			startMenu.rectTransform.position.y-1000);
		StartCoroutine (TS.FadeOut (firstTutScene));
	}

	public void CancelPressed() {
		startMenu.rectTransform.position = new Vector3(startMenu.rectTransform.position.x, 
			startMenu.rectTransform.position.y-1000);
//		DeactivateStart ();
		Activate ();
	}

	public void YesPressed() {
		Application.Quit ();
	}

	public void NoPressed() {
		quitMenu.rectTransform.position = new Vector3(quitMenu.rectTransform.position.x, 
			quitMenu.rectTransform.position.y-1000);
//		DeactivateQuit ();
		Activate ();
	}

	public void JumpPressed() {
		jumpMenu.rectTransform.position = new Vector3 (jumpMenu.rectTransform.position.x,
			jumpMenu.rectTransform.position.y+1000);
		ButtonPressed ();
	}

	public void Jump(string level) {
		jumpMenu.rectTransform.position = new Vector3(jumpMenu.rectTransform.position.x, 
			jumpMenu.rectTransform.position.y-1000);
		StartCoroutine (TS.FadeOut (level));
	} 

	public void JumpCancel() {
		jumpMenu.rectTransform.position = new Vector3(jumpMenu.rectTransform.position.x, 
			jumpMenu.rectTransform.position.y-1000);
		Activate ();
	}
}
