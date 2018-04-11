using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowBehavior : MonoBehaviour {


	public float distance;
	public float sec;
	public float beat;
	public float time;
	public Sprite imLeft, imUp, imDown, imRight;
	Image arrowImage;

	// Use this for initialization
	void Start () {
		distance = 200;

		arrowImage = transform.GetComponent<Image> ();

//			beat = CreateModePIM.beat;
//			time = CreateModePIM.time;


			if (transform.position.y == transform.parent.position.y + 80) {
				arrowImage.sprite = imLeft;
			} else if (transform.position.y == transform.parent.position.y) {
				arrowImage.sprite = imUp;
			} else if (transform.position.y == transform.parent.position.y - 80) {
				arrowImage.sprite = imDown;
			} else {
				arrowImage.sprite = imRight;
			}



			transform.position = new Vector3 (transform.position.x, transform.position.y);

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * Time.deltaTime * distance / sec);
	}
}
