using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour {

	public GameObject[] spriteList;

	// Use this for initialization
	public void Boardmaker()
	{
		GameObject instance;

		//for (int x = 0; x < 36; x++)
		//{
		//	for (int y = 0; y < 36; y++)
		//	{
		//		instance = Instantiate(RandomSprite(), new Vector3(x, y, 0f), Quaternion.identity);
		//		instance.transform.SetParent(gameObject.transform);
		//	}
		//}
		for (float i = 0; i < 36; i++)
		{
			for (float j = 0; j < 10; j++)
			{
				instance = Instantiate(RandomSprite(), new Vector3(Mathf.Sin(i * Mathf.PI / 18) * 5, j, (Mathf.Cos(i * Mathf.PI / 18) * 5)), Quaternion.Euler(0f, 10 * i, 0f), gameObject.transform);
			}
		}
	}

	GameObject RandomSprite()
	{
		return spriteList[Random.Range(0, spriteList.Length)];
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
