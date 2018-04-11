using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Button : MonoBehaviour {

	public TransitionScreen TS;
	public Transform QuitMenu;
	public Transform SecondLayer;

	public void Pressed(string game) {
		StartCoroutine (TS.FadeOut(game));
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void QuitPressed() {
		QuitMenu.position = new Vector3 (QuitMenu.position.x, QuitMenu.position.y + 500);
	}

	public void YesPressed() {
		QuitGame ();
	}

	public void NoPressed() {
		QuitMenu.position = new Vector3 (QuitMenu.position.x, QuitMenu.position.y - 500);
	}

	public void RightPressed () {
		SecondLayer.position = new Vector3 (SecondLayer.position.x, SecondLayer.position.y + 500);
	}

	public void LeftPressed () {
		SecondLayer.position = new Vector3 (SecondLayer.position.x, SecondLayer.position.y - 500);
	}
}
