using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

	GameObject player;
	//public GameObject DEBUG;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player1");
		
	}


	void FixedUpdate () {

		gameObject.GetComponent<Transform>().position = new Vector3(player.transform.position.x, player.transform.position.y, -13f);


		// Gets the Gyroscope Normalized Data
		Vector3 gravnorm = Input.gyro.gravity.normalized;
		float newAngle;

		//Calculates the angle of gravity relative to the X & Y Axes
		if (gravnorm.y < 0)
			newAngle = (180 / Mathf.PI) * Mathf.Atan(gravnorm.x / -Mathf.Abs(gravnorm.y));
		else if (gravnorm.y > 0)
			newAngle = 180 - (180 / Mathf.PI) * Mathf.Atan(gravnorm.x / -Mathf.Abs(gravnorm.y));
		else
			newAngle = 0;

		//Rotates the Map to be consistent with Gravity
		Quaternion rot = Quaternion.Euler(0f, 0f, newAngle);
		gameObject.GetComponent<Transform>().rotation = rot;




		//Quaternion attit = Input.gyro.attitude;
		//Vector3 DebugAtt = attit.eulerAngles;



		//DEBUG.GetComponent<Text>().text =
		////	"ANGLE:" + newAngle +
		////	"\nY Grav: " + (Input.gyro.gravity.y).ToString() + " Y Grav N: " + (Input.gyro.gravity.normalized.y).ToString() +
		////	"\nZ Grav: " + (Input.gyro.gravity.z).ToString() + " Z Grav N: " + (Input.gyro.gravity.normalized.z).ToString() +
		////	"\nX Grav: " + (Input.gyro.gravity.x).ToString() + " X Grav N: " + (Input.gyro.gravity.normalized.x).ToString() +
		//"\nY Gyro: " + DebugAtt.y.ToString() +
		//"\nZ Gyro: " + DebugAtt.z.ToString() +
		//"\nX Gyro: " + DebugAtt.x.ToString() +
		//"\nY Gyro: " + (Input.gyro.rotationRateUnbiased.y).ToString() +
		//"\nZ Gyro: " + (Input.gyro.rotationRateUnbiased.z).ToString() +
		//"\nX Gyro: " + (Input.gyro.rotationRateUnbiased.x).ToString();


	}
}
