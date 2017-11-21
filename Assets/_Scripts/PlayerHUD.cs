using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

	public static PlayerHUD Instance;

	[SerializeField]
	private List<RawImage> healthUI;
	[SerializeField]
	private RawImage hp1;
	[SerializeField]
	private RawImage hp2;

	// Use this for initialization
	void Start () {
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
		UpdateHealth();
	}
	
	public void UpdateHealth()
	{
		int change = healthUI.Count - GameManager.health;
		if (change > 0)
		{
			for (int i = change; i > 0; i--)
			{
				RawImage hp = healthUI[healthUI.Count - 1];
				Destroy(hp);
				healthUI.RemoveAt(healthUI.Count - 1);
			}
		}
		else if (change < 0)
		{
			for (int i = change; i < 0; i++)
			{
				if (healthUI.Count % 2 == 0)
				{
					RawImage hp = Instantiate(hp1, new Vector3 (hp1.transform.position.x + (healthUI.Count / 2 * 100), hp1.transform.position.y), Quaternion.identity, transform);
					healthUI.Add(hp);
				}
				else
				{
					RawImage hp = Instantiate(hp2, new Vector3(hp2.transform.position.x + (healthUI.Count / 2 * 100), hp2.transform.position.y), Quaternion.identity, transform);
					healthUI.Add(hp);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
