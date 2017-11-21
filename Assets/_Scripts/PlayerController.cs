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

	public AudioClip fireClip;
	public AudioClip playerHitClip;

	// Use this for initialization
	void Start()
	{
		mainCamera = GameObject.Find("Main Camera");
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		

		//enables gyroscope
		Input.gyro.enabled = true;

		//Make sure you can move
		if (speed <= 0)
			speed = 2f;

	}
	
	void Update()
	{
		//Rotates to match the camera
		//Quaternion camrot = mainCamera.transform.rotation;
		//transform.rotation = camrot;



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
		if (Time.time > nextShot && ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) | Input.GetMouseButtonDown(0)))
		{
			//Mouse Controls
			if (Input.mousePresent)
			{
				Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				shotSpawn.transform.right = (Vector2)transform.position - (Vector2)pz;
			}
			//Mobile Controls
			else
			{
				Vector3 pz = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				shotSpawn.transform.right = (Vector2)transform.position - (Vector2)pz;
			}

			
			nextShot = Time.time + fireRate;
			AudioManager.Instance.PlayAudio(fireClip);
			Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "EnemyBullet")
		{
			AudioManager.Instance.PlayAudio(playerHitClip);
			Destroy(collider.gameObject);
			GameManager.Instance.UpdateHealth(-1);					
		}
	}
}
