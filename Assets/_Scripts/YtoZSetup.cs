using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YtoZSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float adjust = gameObject.GetComponent<SpriteRenderer>().bounds.extents.y;
		transform.Translate(new Vector3(0f, 0f, transform.position.y - adjust - transform.position.z));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
