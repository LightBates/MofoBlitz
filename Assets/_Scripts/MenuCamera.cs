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
			if ((gyroAttY > 70 & gyroAttY < 110) || (gyroAttY > 250 & gyroAttY < 290))
			{
				startButton.interactable = true;
				startText.text = "Start";
			}
			else
			{
				startButton.interactable = false;
				startText.text = "Hold Device Straight Forward";
			}
		}
	}
}
