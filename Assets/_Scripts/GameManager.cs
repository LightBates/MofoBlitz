using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public static int score;
	public static int health { get; private set; }

	public static GameManager Instance = null;
	private int level;

	void Awake ()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

		Reset();
	}

	public void Reset()
	{
		score = 0;
		level = 1;
		health = 8;
	}


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		if (health <= 0)
		{
			Reset();
			SceneManager.LoadScene(0);

		}
		else if (score == 36)
		{
			score++;
			level++;
			SceneManager.LoadScene(level);
		}
	}

	public void UpdateHealth(int modifier)
	{
		health = health + modifier;
		PlayerHUD.Instance.UpdateHealth();
	}
}
