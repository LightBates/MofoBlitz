using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	
	private GameObject mainCamera;
	private Rigidbody2D rb2d;
	Vector3 adjustment;
	public float speed;

	public Transform shotSpawn;
	public GameObject bullet;
	public float fireRate;
	float nextShot;

	// Use this for initialization
	void Start()
	{
		mainCamera = GameObject.Find("Main Camera");
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		

		//enables gyroscope
		Input.gyro.enabled = true;

		if (speed <= 0)
			speed = .5f;

	}
	
	void Update()
	{
		Quaternion camrot = mainCamera.transform.rotation;
		transform.rotation = camrot;


		if (Time.time > nextShot && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) | Input.GetKeyDown(KeyCode.Space)))
		{
			nextShot = Time.time + fireRate;
			Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate()
	{
		Vector3 camrot = mainCamera.transform.rotation.eulerAngles;
		float camzrad = camrot.z * Mathf.PI / 180;

		//COMPUTER CONTROLS
		//float horiz = Input.GetAxis("Horizontal");
		//float vert = Input.GetAxis("Vertical");


		float xRate = Mathf.Round(Input.gyro.rotationRateUnbiased.x * 100f) / 100f;
		float yRate = Mathf.Round(Input.gyro.rotationRateUnbiased.y * 100f) / 100f;

		//MOBILE CONTROLS
		float vert = (Mathf.Sin(camzrad) * (-yRate) + Mathf.Cos(camzrad) * (xRate)) * speed;
		float horiz = (Mathf.Cos(camzrad) * (-yRate) + Mathf.Sin(camzrad) * (xRate)) * speed;

		Vector3 targetPos = transform.position + new Vector3(horiz * speed * Time.deltaTime, vert * speed * Time.deltaTime);

		rb2d.MovePosition(targetPos);
		//transform.localPosition += new Vector3(horiz * speed * Time.deltaTime, vert * speed * Time.deltaTime);


		//Camera Controls for Cylinderboard
		//transform.Translate(0f, (Input.acceleration.z - adjustment.z) / 2f, 0f);
		//transform.Rotate(0f, -Input.gyro.rotationRateUnbiased.y, 0f);

		//Camera Controls for Flatboard
		//transform.Translate(-Input.gyro.rotationRateUnbiased.y / 8f, (Input.acceleration.z - adjustment.z) / 8f, 0f);

		//		//Maintains Upper and Lower Y Bounds
		//		if (transform.position.y > 10)
		//			transform.SetPositionAndRotation(new Vector3(transform.position.x, 10f, transform.position.z), transform.rotation);
		//		else if (transform.position.y < 0)
		//			transform.SetPositionAndRotation(new Vector3(transform.position.x, 0f, transform.position.z), transform.rotation);

		//		//Maintians Upper and Lower X Bounds(FLATBOARD ONLY)
		//		if (transform.position.x > 18)
		//			transform.SetPositionAndRotation(new Vector3(18f, transform.position.y, transform.position.z), transform.rotation);
		//		else if (transform.position.x < -18)
		//			transform.SetPositionAndRotation(new Vector3(-18f, transform.position.y, transform.position.z), transform.rotation);
	}
}
