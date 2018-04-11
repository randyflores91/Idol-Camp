using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play_Movie_Background : MonoBehaviour {

	public MovieTexture movie;
	int vsyncprevious;

	// Use this for initialization
	void Start () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		vsyncprevious = QualitySettings.vSyncCount;
		QualitySettings.vSyncCount = 0;
		movie.Play();
		movie.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!movie.isPlaying)
		{
			QualitySettings.vSyncCount = vsyncprevious;
		}
	}
}
