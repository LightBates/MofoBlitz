using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Vector3 adjustment;

	// Use this for initialization
	void Start () {

		//Sets a base adjustment so if the phone starts angled the camera doesn't start scrolling
		adjustment = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);

		//enables gyroscope
		Input.gyro.enabled = true;
		
	}

	/// <summary>
	/// A function for re-zeroing the accelerometer adjustment
	/// </summary>
	public void Zero()
	{
		adjustment = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);		
	}
	
	// Update is called once per frame
	void Update () {

		///Camera Controls for Cylinderboard

		transform.Translate(0f, Input.acceleration.z - adjustment.z, 0f);
		transform.Rotate(0f, -Input.gyro.rotationRateUnbiased.y, 0f);

		///Camera Controls for Flatboard

		//transform.Translate(-Input.gyro.rotationRateUnbiased.y / 8, Input.acceleration.z - adjustment.z, 0f);

		///Maintains Upper and Lower Y Bounds
		if (transform.position.y > 10)
			transform.SetPositionAndRotation(new Vector3(transform.position.x, 10f, transform.position.z), transform.rotation);
		else if (transform.position.y < 0)
			transform.SetPositionAndRotation(new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation);
		///Maintians Upper and Lower X Bounds (FLATBOARD ONLY)
		//if (transform.position.x > 18)
		//	transform.SetPositionAndRotation(new Vector3(18f, transform.position.y, transform.position.z), transform.rotation);
		//else if (transform.position.x < -18)
		//	transform.SetPositionAndRotation(new Vector3(-18f, transform.position.y, transform.position.z), transform.rotation);

	}
}
