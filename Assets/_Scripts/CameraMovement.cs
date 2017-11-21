using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

	GameObject player;
	public float speed;

	public float levelTop;
	public float levelBottom;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player1");
		//Orient();
	}

	public void Orient()
	{
		if (!Input.mousePresent)
		{
			float gyroAttY = Input.gyro.attitude.eulerAngles.y;
			if (gyroAttY > 150)
				gyroAttY = 150;
			else if (gyroAttY < 30)
				gyroAttY = 30;
			float targety = ((gyroAttY - 30) / 120) * (levelTop - levelBottom) + levelBottom;

			gameObject.transform.position = new Vector3(transform.position.x, targety, transform.position.z);
		}		
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

		Vector3 targetPos = transform.position + new Vector3(horiz * speed * Time.deltaTime, vert * speed * Time.deltaTime);
		if (targetPos.y > levelTop)
			targetPos.y = levelTop;
		else if (targetPos.y < levelBottom)
			targetPos.y = levelBottom;
		gameObject.GetComponent<Rigidbody2D>().MovePosition(targetPos);
	}
}
