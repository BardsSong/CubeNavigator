using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {

	public void LoadLevel1()
	{
		SceneManager.LoadScene("Level_1");
	}

	public void LoadLevel2()
	{
		SceneManager.LoadScene("Level_2");
	}

	public void LoadLevel3()
	{
		SceneManager.LoadScene("Level_3");
	}

	public void BackButton()
	{
		SceneManager.LoadScene("Main_Menu");
	}

}
