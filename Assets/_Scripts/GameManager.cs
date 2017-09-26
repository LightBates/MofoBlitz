using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		//Creates the Map
		gameObject.GetComponent<MapGen>().Boardmaker();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
