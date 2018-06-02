using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour {
	// Use this for initialization
	private LineManager _lineManager;
	public LineRenderer lineOne;
	public LineRenderer lineTwo;
	void Start ()
	{
		_lineManager = GameObject.Find("PlayerRayManager").GetComponent<LineManager>();
		lineOne.positionCount = _lineManager.lineOnePositions.Length;
		lineTwo.positionCount = _lineManager.lineTwoPositions.Length;
		for (int i = 0; i < _lineManager.lineOnePositions.Length; i++)
		{
			lineOne.SetPosition(i, _lineManager.lineOnePositions[i]);
		}
		for (int i = 0; i < _lineManager.lineTwoPositions.Length; i++)
		{
			lineTwo.SetPosition(i, _lineManager.lineTwoPositions[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
