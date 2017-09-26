using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

	GameObject player;
	float adjustment;
	public GameObject DEBUG;

	// Use this for initialization
	void Start () {
		adjustment = Input.gyro.rotationRateUnbiased.z;
		player = GameObject.Find("Player1");
		
	}


	void FixedUpdate () {

		gameObject.GetComponent<Transform>().position = new Vector3(player.transform.position.x, player.transform.position.y, 0f);

		//Quaternion rot = Input.gyro.attitude;
		//Vector3 rotEuler = rot.eulerAngles;
		//Vector3 rotCurrent = transform.rotation.eulerAngles;
		//rot.eulerAngles = new Vector3(rotCurrent.x, rotCurrent.y, rotEuler.z);

		//gameObject.GetComponent<Transform>().rotation = rot;

		//float rotateplz = Input.gyro.rotationRateUnbiased.z;
		//transform.Rotate(Vector3.forward, rotateplz);

		
		Quaternion rot;
		if (Input.gyro.gravity.normalized.x < 0)
			rot = Quaternion.Euler(0f, 0f, (180 / Mathf.PI) * Mathf.Acos(-Input.gyro.gravity.normalized.y));
		else
			rot = Quaternion.Euler(0f, 0f, -((180 / Mathf.PI) * Mathf.Acos(-Input.gyro.gravity.normalized.y)));
		gameObject.GetComponent<Transform>().rotation = rot;

		DEBUG.GetComponent<Text>().text = "Y Grav N: " + (Input.gyro.gravity.y).ToString() + "\nZ Grav N: " + (Input.gyro.gravity.z).ToString() + "\nX Grav N: " + (Input.gyro.gravity.x).ToString()
			+ "\nY Gyro: " + (Input.gyro.rotationRateUnbiased.y).ToString() + "\nZ Gyro: " + (Input.gyro.rotationRateUnbiased.z).ToString() + "\nX Gyro: " + (Input.gyro.rotationRateUnbiased.x).ToString();
		

	}
}
