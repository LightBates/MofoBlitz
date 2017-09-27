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

		//Formula ideas for sure rotation.
		//-cos(y)*cos(x) + sin(z)*cos(x)???? -cos(z)sin(y)?

		Vector3 gravnorm = Input.gyro.gravity.normalized;

		Quaternion rot = Quaternion.Euler (0f, 0f, (180 / Mathf.PI) * (Mathf.Acos (-gravnorm.y) * Mathf.Acos (gravnorm.x)
			+ Mathf.Asin(gravnorm.z) * Mathf.Acos(gravnorm.x)));
		gameObject.GetComponent<Transform>().rotation = rot;

		//Backup of attempt at z fix
		//Quaternion rot;
		//if (Input.gyro.gravity.normalized.x < 0)
		//	rot = Quaternion.Euler(0f, 0f, (180 / Mathf.PI) * (Mathf.Acos(-gravnorm.y)
		//		+ Mathf.Abs(Mathf.Asin(-gravnorm.z))));
		//else
		//	rot = Quaternion.Euler(0f, 0f, -(180 / Mathf.PI) * (Mathf.Acos(-gravnorm.y)
		//		+ Mathf.Abs(Mathf.Asin(-gravnorm.z))));
		//gameObject.GetComponent<Transform>().rotation = rot;


		Quaternion attit = Input.gyro.attitude;
		Vector3 DebugAtt = attit.eulerAngles;



		DEBUG.GetComponent<Text>().text =
			"Y Grav: " + (Input.gyro.gravity.y).ToString() + " Y Grav N: " + (Input.gyro.gravity.normalized.y).ToString() +
			"\nZ Grav: " + (Input.gyro.gravity.z).ToString() + " Z Grav N: " + (Input.gyro.gravity.normalized.z).ToString() +
			"\nX Grav: " + (Input.gyro.gravity.x).ToString() + " X Grav N: " + (Input.gyro.gravity.normalized.x).ToString() +
			"\nY Gyro: " + DebugAtt.y.ToString() +
			"\nZ Gyro: " + DebugAtt.z.ToString() +
			"\nX Gyro: " + DebugAtt.x.ToString() +
			"\nY Gyro: " + (Input.gyro.rotationRateUnbiased.y).ToString() + 
			"\nZ Gyro: " + (Input.gyro.rotationRateUnbiased.z).ToString() +
			"\nX Gyro: " + (Input.gyro.rotationRateUnbiased.x).ToString();
		

	}
}
