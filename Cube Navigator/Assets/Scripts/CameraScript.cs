using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	[SerializeField] float rotation = 0;
	[SerializeField] GameObject cameraArm = null;

	void Update () {
		Vector3 position = Input.mousePosition;
		float yo = Screen.height;
		rotation = Mathf.LerpAngle(0, 45, position.y / yo);

		cameraArm.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
	}
}
