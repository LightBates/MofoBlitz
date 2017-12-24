using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

	public float fireRate;
	float nextShot;
	public GameObject bullet;
	public bool InRange;
	public Transform shotSpawn;
	public float speed;

	public GameObject player;
	Rigidbody2D rb2d;
	
	public AudioClip enemyFireClip;

	// Use this for initialization
	void Start () {
		InRange = false;
		nextShot = 0;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		if (speed == 0)
		{
			speed = .05f;
		}
	}

	void OnDestroy ()
	{
		GameManager.Instance.ScoreUp();
	}

	// Update is called once per frame
	void Update () {
		if (InRange)
		{
			Vector2 target = transform.position - player.transform.position;
			shotSpawn.transform.right = target;
			if (Time.time >= nextShot)
			{
				nextShot = Time.time + fireRate;
				gameObject.GetComponent<Animator>().SetTrigger("Attack");
				AudioManager.Instance.PlayAudio(enemyFireClip);
				Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
			}

			Vector2 targetPos = player.transform.position;
			Vector2 targetVec = targetPos - (Vector2)transform.position;
			if (targetVec.magnitude > 3)
			{
				rb2d.MovePosition((Vector2)transform.position + (targetVec.normalized * speed));
			}
		}
	}
	
}
