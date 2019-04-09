using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour {

	[SerializeField] string nextLevel = "";
	[SerializeField] ParticleSystem fireworks = null;

	AsyncOperation async;
	int count = 0;

	public void StartLoading()
	{
		if (count == 0)
		{
			count++;
			StartCoroutine("loadNextLevel");
		}
	}

	IEnumerator loadNextLevel()
	{
		Debug.Log("PLEASE DO NOT STOP EDITOR - IT WILL CRASH");
		async = SceneManager.LoadSceneAsync(nextLevel);
		async.allowSceneActivation = false;
		yield return async;
	}

	private void Update()
	{
		if (async != null)
		{
			if (fireworks.isStopped && async.progress == .9f)
			{
				async.allowSceneActivation = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			fireworks.Play();
			StartLoading();
		}
	}
}
