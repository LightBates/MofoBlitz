using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetection : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			gameObject.GetComponentInParent<EnemyBehavior>().InRange = true;
			gameObject.GetComponentInParent<EnemyBehavior>().player = collider.gameObject;
		}

	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			gameObject.GetComponentInParent<EnemyBehavior>().InRange = false;
		}
	}
}
