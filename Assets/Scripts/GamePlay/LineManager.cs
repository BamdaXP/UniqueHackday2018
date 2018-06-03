using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
	public Vector3[] lineOnePositions;

	public Vector3[] lineTwoPositions;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
}
