using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menus : MonoBehaviour {

	[SerializeField] string firstLevel = "";
	[SerializeField] string levelSelect = "";
	[SerializeField] Image confirmWindow = null;
	[SerializeField] Camera mainCamera = null;


	private void Update()
	{
		if (Input.GetButton("Pause"))
		{
			confirmWindow.gameObject.SetActive(true);
			
		}
	}
	public void StartClick()
	{
		SceneManager.LoadScene(firstLevel);
	}

	public void LevelSelect()
	{
		SceneManager.LoadScene(levelSelect);
	}

	public void QuitTryOne()
	{
		confirmWindow.gameObject.SetActive(true);
	}

	public void QuitTwoSuccess()
	{
		confirmWindow.gameObject.SetActive(false);
	}

	public void QuitToMenu()
	{
		SceneManager.LoadScene("Main_Menu");
	}

	public void QuitTryTwo()
	{
		Application.Quit();
	}
}
