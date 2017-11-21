using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCamera : MonoBehaviour {

	[SerializeField]
	Button startButton;
	[SerializeField]
	Text startText;

	// Use this for initialization
	void Start()
	{
		Input.gyro.enabled = true;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	void Update()
	{
		if (!Input.mousePresent)
		{
			float gyroAttY = Input.gyro.attitude.eulerAngles.y;
			if (gyroAttY < 80 || gyroAttY > 100)
			{
				startButton.interactable = false;
				startText.text = "Hold Device Straight Forward";
			}
			else
			{
				startButton.interactable = true;
				startText.text = "Start";
			}
		}
	}
}
