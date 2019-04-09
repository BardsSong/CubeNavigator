using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {


	List<float> totalRotation = new List<float>();
	static float leftValue = 5f;
	static float rightValue = -5f;

	[SerializeField] int currentCube = 0;
	[SerializeField] List<GameObject> cubes = new List<GameObject>();

	List<GameObject> rotatingCubesLeft = new List<GameObject>();
	List<GameObject> rotatingCubesRight = new List<GameObject>();

	private void Start()
	{
		for (int i = 0; i < cubes.Count; i++)
		{
			totalRotation.Add(0f);
		}
	}

	void Update () {

		if (cubes.Count > 0)
		{
			for (int i = 0; i < totalRotation.Count; i++)
			{
				totalRotation[i] %= 90;
				if (totalRotation[i] == 0)
				{
					if (rotatingCubesLeft.Contains(cubes[i]))
					{
						rotatingCubesLeft.Remove(cubes[i]);
					}
					else if (rotatingCubesRight.Contains(cubes[i]))
					{
						rotatingCubesRight.Remove(cubes[i]);
					}
				}
			}

			if (Input.GetButtonDown("RotateL"))
			{
				rotatingCubesLeft.Add(cubes[currentCube]);
			}
			else if (Input.GetButtonDown("RotateR"))
			{
				rotatingCubesRight.Add(cubes[currentCube]);
			}

			for (int i = 0; i < cubes.Count; i++)
			{
				if (rotatingCubesLeft.Contains(cubes[i]) && rotatingCubesLeft[0] != null)
				{
					int index = rotatingCubesLeft.IndexOf(cubes[i]);
					if (index >= 0 && index < rotatingCubesLeft.Count)
					{
						rotatingCubesLeft[index].transform.Rotate(0, leftValue, 0, Space.Self);
						totalRotation[i] += leftValue;
					}
				}
				else if (rotatingCubesRight.Contains(cubes[i]) && rotatingCubesRight[0] != null)
				{
					int index = rotatingCubesRight.IndexOf(cubes[i]);
					if (index >= 0 && index < rotatingCubesRight.Count)
					{
						rotatingCubesRight[index].transform.Rotate(0, rightValue, 0, Space.Self);
						totalRotation[i] += rightValue;
					}
				}
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				currentCube++;
				currentCube %= cubes.Count;
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (currentCube > 0)
				{
					currentCube--;
				}
				else
				{
					currentCube = cubes.Count - 1;
				}
			}
		}

	}
}
