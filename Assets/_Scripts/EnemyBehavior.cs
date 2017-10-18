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


	public GameObject player;
	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		InRange = false;
		nextShot = 0;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (InRange)
		{
			Vector2 target = gameObject.transform.position - player.transform.position;
			transform.right = target;
			if (Time.time >= nextShot)
			{
				nextShot = Time.time + fireRate;
				Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
			}
		}
	}
}
