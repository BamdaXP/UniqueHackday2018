using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			LineManager manager = GameObject.Find("PlayerRayManager").GetComponent<LineManager>();
			LineRenderer lineOne = GameObject.Find("LineOne").GetComponent<LineRenderer>();
			LineRenderer lineTwo = GameObject.Find("LineTwo").GetComponent<LineRenderer>();
			int countOne = lineOne.numPositions, countTwo = lineTwo.numPositions;
			manager.lineOnePositions = new Vector3[countOne];
			manager.lineTwoPositions = new Vector3[countTwo];
			for (int i = 1; i < countOne; i++)
			{
				manager.lineOnePositions[i] = lineOne.GetPosition(i) - lineOne.GetPosition(0);
			}

			manager.lineOnePositions[0] = Vector3.zero;
			for (int i = 1; i < countTwo; i++)
			{
				manager.lineTwoPositions[i] = lineTwo.GetPosition(i) - lineTwo.GetPosition(0);
			}

			manager.lineTwoPositions[0] = Vector3.zero;
			SceneManager.LoadScene("test_level");
		}
	}
}
