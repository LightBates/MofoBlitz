using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour {

	public float speed;

	public AudioClip enemyHitClip;


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
				AudioManager.Instance.PlayAudio(enemyHitClip);
				Destroy(collider.gameObject);
				Destroy(gameObject);
				break;
			case "EnemyBullet":
				Destroy(gameObject);
				break;
		}

	}

	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
	}
}
