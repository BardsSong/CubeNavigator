using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	[SerializeField] float m_speed = 0.0f;
	[SerializeField] float m_rotateSpeed = 0.0f;

	private void Update()
	{
		if (Input.GetAxis("Vertical") == 0)
		{
			this.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * m_rotateSpeed * Time.deltaTime, 0), Space.Self);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Level")
		{
			this.gameObject.transform.parent = other.gameObject.transform;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		this.gameObject.transform.parent = null;
	}
}
