using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {


	void Awake () {
		//if (GameManager.Instance == null)
		//{
		//	Instantiate(gameManager);
		//	GameManager.Instance.Reset();
		//}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartPressed()
	{
		GameManager.Instance.playing = true;
		GameManager.Instance.NextLevel();
	}

	public void ExitPressed()
	{
		Application.Quit();
	}

	public void MenuPressed()
	{
		GameManager.Instance.Reset();
		SceneManager.LoadScene(0);
	}
}
