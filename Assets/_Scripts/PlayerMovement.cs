using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private GameObject mainCamera;
	private Rigidbody2D rb2d;
	Vector3 adjustment;
	public float speed;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find ("MainCamera");
		rb2d = gameObject.GetComponent<Rigidbody2D>();

		//enables gyroscope
		Input.gyro.enabled = true;

		speed = 1;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 camrot = mainCamera.transform.rotation.eulerAngles;
		float camzrad = camrot.z * Mathf.PI / 180;

		//COMPUTER CONTROLS
		//float horiz = Input.GetAxis("Horizontal");
		//float vert = Input.GetAxis("Vertical");

		//MOBILE CONTROLS
		float vert = (Mathf.Sin(camzrad)*(-Input.gyro.rotationRateUnbiased.y) + Mathf.Cos(camzrad)*(Input.gyro.rotationRateUnbiased.x)) * speed;
		//float vert = (Input.acceleration.z - adjustment.z) * 1f;
		float horiz = (Mathf.Cos(camzrad)*(-Input.gyro.rotationRateUnbiased.y) + Mathf.Sin(camzrad)*(Input.gyro.rotationRateUnbiased.x)) * speed;



		rb2d.velocity = new Vector2(horiz * speed, vert * speed);

		//Camera Controls for Cylinderboard
		//transform.Translate(0f, (Input.acceleration.z - adjustment.z) / 2f, 0f);
		//transform.Rotate(0f, -Input.gyro.rotationRateUnbiased.y, 0f);

		//Camera Controls for Flatboard
		//transform.Translate(-Input.gyro.rotationRateUnbiased.y / 8f, (Input.acceleration.z - adjustment.z) / 8f, 0f);

		//Maintains Upper and Lower Y Bounds
		if (transform.position.y > 10)
			transform.SetPositionAndRotation(new Vector3(transform.position.x, 10f, transform.position.z), transform.rotation);
		else if (transform.position.y < 0)
			transform.SetPositionAndRotation(new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation);

		//Maintians Upper and Lower X Bounds(FLATBOARD ONLY)
		if (transform.position.x > 18)
			transform.SetPositionAndRotation(new Vector3(18f, transform.position.y, transform.position.z), transform.rotation);
		else if (transform.position.x < -18)
			transform.SetPositionAndRotation(new Vector3(-18f, transform.position.y, transform.position.z), transform.rotation);
	}
}
