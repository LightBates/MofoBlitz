using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YtoZLayerSort : MonoBehaviour {

	float adjust;

	// Use this for initialization
	void Start () {
		adjust = gameObject.GetComponent<SpriteRenderer>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0f, 0f, transform.position.y - adjust - transform.position.z));
	}
}
