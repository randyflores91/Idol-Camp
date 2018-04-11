using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour {

	public GameObject player1, player2, player3, player4;
	Player p1,p2,p3,p4;
	int location;
	float space = 105f;
	float upspace = 120f;

	// Use this for initialization
	void Start () {
		p1 = player1.GetComponent<Player> ();
		p2 = player2.GetComponent<Player> ();
		p3 = player3.GetComponent<Player> ();
		p4 = player4.GetComponent<Player> ();

		int starter = Random.Range (1, 5);
		location = starter;
		switch (starter) {
		case 1:
			p1.turn = true;
			break;
		case 2:
			p2.turn = true;
			break;
		case 3:
			p3.turn = true;
			break;
		case 4:
			p4.turn = true;
			break;
		}
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
