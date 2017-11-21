using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	[SerializeField]
	private GameManager gameManager;


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
		SceneManager.LoadScene(1);
	}

	public void ExitPressed()
	{
		Application.Quit();
	}
}
