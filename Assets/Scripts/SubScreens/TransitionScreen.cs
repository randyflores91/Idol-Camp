using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionScreen : MonoBehaviour {

	Transform trans;
	Animator anim;
	Image fadeImage;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		fadeImage = GetComponent<Image> ();
		trans = GetComponent<Transform> ();
		trans.position = new Vector3(trans.parent.position.x, trans.parent.position.y-1000f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator FadeOut (string scene) {
		trans.position = new Vector3(trans.parent.position.x, trans.parent.position.y, 0f);
		anim.SetBool ("FadeOut", true);
		yield return new WaitUntil (()=>fadeImage.color.a == 1);
		SceneManager.LoadScene (scene);
	}

	public IEnumerator FadeIn() {
		trans.position = new Vector3(trans.parent.position.x, trans.parent.position.y, 0f);
		anim.SetBool ("FadeIn", true);
		yield return new WaitUntil (()=>fadeImage.color.a == 0);
		trans.position = new Vector3(trans.parent.position.x, trans.parent.position.y-1000f, 0f);
	}

	public void FadeIn2() {
		anim.SetBool ("FadeIn", true);
	}
}
