using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D>().velocity = transform.forward * speed;
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		switch (collider.gameObject.tag)
		{
			case "Environment":
				Destroy(gameObject);
				break;
			case "Enemy":
				Destroy(collider.gameObject);
				Destroy(gameObject);
				GameManager.score++;
				break;
			case "Bullet":
				Destroy(gameObject);
				break;
		}

	}

	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
	}
}
