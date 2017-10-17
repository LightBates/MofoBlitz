using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

	bool canFire;

	// Use this for initialization
	void Start () {
		canFire = true;
	}


	void FixedUpdate () {
		Input.GetTouch(0);
	}
}
