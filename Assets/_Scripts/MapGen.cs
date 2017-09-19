using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour {

	public GameObject[] spriteList;

	// Use this for initialization
	public void Boardmaker()
	{
		GameObject instance;

		///Creates a Flatboard of X by Y

		//for (int x = -18; x < 18; x++)
		//{
		//	for (int y = 0; y < 10; y++)
		//	{
		//		instance = Instantiate(RandomSprite(), new Vector3(x, y, 1f), Quaternion.identity);
		//		instance.transform.SetParent(gameObject.transform);
		//	}
		//}

		///Creates a Cylinderboard of 36 sides and height Y
		///To change the number of sides will require adjusting the formula

		for (float x = 0; x < 36; x++)
		{
			for (float y = 0; y < 10; y++)
			{
				instance = Instantiate(RandomSprite(), new Vector3(Mathf.Sin(x * Mathf.PI / 18) * (.5f / Mathf.Tan(Mathf.PI / 36)), y, (Mathf.Cos(x * Mathf.PI / 18) * (.5f / Mathf.Tan(Mathf.PI / 36)))), Quaternion.Euler(0f, 10 * x, 0f), gameObject.transform);
			}
		}
	}

	//Picks a random Sprite from the SpriteList
	GameObject RandomSprite()
	{
		return spriteList[Random.Range(0, spriteList.Length)];
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
