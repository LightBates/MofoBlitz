using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetweenLevelCamera : MonoBehaviour {

	[SerializeField]
	Button startButton;
	[SerializeField]
	Text startText;
	[SerializeField]
	Text ScoreText;

	// Use this for initialization
	void Start()
	{
		ScoreText.text = "Current Score: " + GameManager.Instance.totalscore.ToString();
	}

	void Update()
	{
		if (!Input.mousePresent)
		{
			float gyroAttY = Input.gyro.attitude.eulerAngles.y;
			if ((gyroAttY > 70 & gyroAttY < 110) || (gyroAttY > 250 & gyroAttY < 290))
			{
				startButton.interactable = true;
				startText.text = "Next Level";
			}
			else
			{
				startButton.interactable = false;
				startText.text = "Hold Device Straight Forward";
			}
		}
	}
}
