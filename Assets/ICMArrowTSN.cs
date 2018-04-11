using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICMArrowTSN : MonoBehaviour {

	public GameObject player1, player2, player3, player4;
	ICMPlayerTSN p1,p2,p3,p4;
	float space = 105f;
	float upspace = 120f;

	// Use this for initialization
	void Start () {
		p1 = player1.GetComponent<ICMPlayerTSN> ();
		p2 = player2.GetComponent<ICMPlayerTSN> ();
		p3 = player3.GetComponent<ICMPlayerTSN> ();
		p4 = player4.GetComponent<ICMPlayerTSN> ();

		p2.turn = true;
		p3.turn = false;
		p4.turn = false;
		p1.turn = false;
	}

	// Update is called once per frame
	void Update () {
		if (p1.turn)
			transform.position = player1.GetComponent<Transform> ().position + Vector3.left * space
				+ Vector3.up * upspace;
		if (p2.turn)
			transform.position = player2.GetComponent<Transform> ().position + Vector3.left * space
				+ Vector3.up * upspace;
		if (p3.turn)
			transform.position = player3.GetComponent<Transform> ().position + Vector3.left * space
				+ Vector3.up * upspace;
		if (p4.turn)
			transform.position = player4.GetComponent<Transform> ().position + Vector3.left * space
				+ Vector3.up * upspace;
	}
}
