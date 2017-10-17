using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public GameObject Player;
	public static int score;

	// Use this for initialization
	void Start () {
		score = 0;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.GetComponent<PlayerController>().health <= 0 | score == 8)
		{
			SceneManager.LoadScene(0);
		}
	}
}
