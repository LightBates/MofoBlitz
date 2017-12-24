using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCamera : MonoBehaviour {


	[SerializeField]
	Text ScoreText;

	// Use this for initialization
	void Start()
	{
		ScoreText.text = "Total Score: " + GameManager.Instance.GetScore();
	}
}
