using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	Vector3 adjustment;

	// Use this for initialization
	void Start () {
		adjustment = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);
		Input.gyro.enabled = true;
		
	}

	public void Zero()
	{
		adjustment = new Vector3(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);		
	}
	
	// Update is called once per frame
	void Update () {
		

		transform.Translate(0f, Input.acceleration.z - adjustment.z, 0f);
		//transform.Rotate(0f, Input.acceleration.x - adjustment.x, 0f);
		transform.Rotate(0f, -Input.gyro.rotationRateUnbiased.y, 0f);
		if (transform.position.y > 10)
			transform.SetPositionAndRotation(new Vector3(transform.position.x, 10f, transform.position.z), transform.rotation);
		else if (transform.position.y < 0)
			transform.SetPositionAndRotation(new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation);

	}
}
