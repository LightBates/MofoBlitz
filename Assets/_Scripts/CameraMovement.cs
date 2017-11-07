using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

	GameObject player;
	public float speed;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player1");
	}


	void FixedUpdate() {

		//gameObject.GetComponent<Transform>().position = new Vector3(player.transform.position.x, player.transform.position.y, -13f);

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






		//Gets the current camera rotation to calculate the angle adjustment on the axes controls
		Vector3 camrot = transform.rotation.eulerAngles;
		float camzrad = camrot.z * Mathf.PI / 180;


		float vert;
		float horiz;

		//COMPUTER CONTROLS
		if (Input.mousePresent)
		{
			horiz = Input.GetAxis("Horizontal");
			vert = Input.GetAxis("Vertical");
		}

		//MOBILE CONTROLS
		else
		{			
			float xRate = Mathf.Round(Input.gyro.rotationRateUnbiased.x * 100f) / 100f;
			float yRate = Mathf.Round(Input.gyro.rotationRateUnbiased.y * 100f) / 100f;
			vert = (Mathf.Sin(camzrad) * (-yRate) + Mathf.Cos(camzrad) * (xRate));
			horiz = (Mathf.Cos(camzrad) * (-yRate) + Mathf.Sin(camzrad) * (-xRate));
		}		

		//Player Movement
		Vector3 targetPos = transform.position + new Vector3(horiz * speed * Time.deltaTime, vert * speed * Time.deltaTime);
		gameObject.GetComponent<Rigidbody2D>().MovePosition(targetPos);
	}
}
