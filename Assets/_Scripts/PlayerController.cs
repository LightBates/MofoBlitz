using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	
	private GameObject mainCamera;
	private Rigidbody2D rb2d;
	Vector3 adjustment;
	public float speed;
	public float health;

	public Transform shotSpawn;
	public GameObject bullet;
	public float fireRate;
	float nextShot;

	// Use this for initialization
	void Start()
	{
		mainCamera = GameObject.Find("Main Camera");
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		health = 100;
		

		//enables gyroscope
		Input.gyro.enabled = true;

		//Make sure you can move
		if (speed <= 0)
			speed = 2f;

	}
	
	void Update()
	{
		//Rotates to match the camera
		Quaternion camrot = mainCamera.transform.rotation;
		transform.rotation = camrot;

		Vector2 targetPos = mainCamera.transform.position;
		Vector2 targetVec = targetPos - (Vector2)transform.position;
		if (targetVec.magnitude < 1)
		{
			rb2d.MovePosition(targetPos);
		}
		else
		{
			rb2d.velocity = targetVec.normalized * speed;
		}

		//If enough time has passed between shots and the shot input is entered, fire a shot
		if (Time.time > nextShot && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) | Input.GetKeyDown(KeyCode.Space)))
		{
			nextShot = Time.time + fireRate;
			Instantiate(bullet, shotSpawn);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Bullet")
		{
			health -= 25;
			Destroy(collider.gameObject);
		}

	}

	void FixedUpdate()
	{
		////Gets the current camera rotation to calculate the angle adjustment on the axes controls
		//Vector3 camrot = mainCamera.transform.rotation.eulerAngles;
		//float camzrad = camrot.z * Mathf.PI / 180;

		////COMPUTER CONTROLS
		////float horiz = Input.GetAxis("Horizontal");
		////float vert = Input.GetAxis("Vertical");

		////MOBILE CONTROLS
		//float xRate = Mathf.Round(Input.gyro.rotationRateUnbiased.x * 100f) / 100f;
		//float yRate = Mathf.Round(Input.gyro.rotationRateUnbiased.y * 100f) / 100f;
		//float vert = (Mathf.Sin(camzrad) * (-yRate) + Mathf.Cos(camzrad) * (xRate)) * speed;
		//float horiz = (Mathf.Cos(camzrad) * (-yRate) + Mathf.Sin(camzrad) * (xRate)) * speed;

		////Player Movement
		//Vector3 targetPos = transform.position + new Vector3(horiz * speed * Time.deltaTime, vert * speed * Time.deltaTime);
		//rb2d.MovePosition(targetPos);


		//Player Movement
		//Vector3 targetPos = mainCamera.transform.position;
		//rb2d.velocity = (targetPos - transform.position).normalized * speed;
		//rb2d.MovePosition(targetPos);
	}
}
