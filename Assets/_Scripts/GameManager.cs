﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<MapGen>().Boardmaker();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
