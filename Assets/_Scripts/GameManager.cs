using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField]
	public int score;
	[SerializeField]
	public int totalscore;
	public bool playing;
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
		totalscore = 0;
		level = 0;
		health = 8;
	}


	// Use this for initialization
	void Start () {
		
	}

	public void ScoreUp()
	{
		if (playing)
		{
			score++;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (health <= 0 && playing)
		{
			playing = false;
			totalscore += score;
			score = 0;
			SceneManager.LoadScene(5);
		}
		else if (score > 0 && score % 36 == 0)
		{
			totalscore += score;
			score = 0;
			SceneManager.LoadScene(4);
		}
	}

	public string GetScore()
	{
		return totalscore.ToString();
	}

	public void NextLevel()
	{
		if (level < 3)
			level++;
		else
			level = 1;
		SceneManager.LoadScene(level);
	}

	public void UpdateHealth(int modifier)
	{
		health = health + modifier;
		PlayerHUD.Instance.UpdateHealth();
	}
}
