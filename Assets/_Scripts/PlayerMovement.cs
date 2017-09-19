using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.Find("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 target = mainCamera.transform.position;
		gameObject.GetComponent<Transform>().position = new Vector3(target.x, target.y, -.5f);
	}
}
