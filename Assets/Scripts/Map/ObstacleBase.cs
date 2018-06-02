using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBase : MonoBehaviour {
	public enum ObstacleType
	{
		Wall, Glass
	}
	[SerializeField]
	private ObstacleType _obstacleType;
	public ObstacleType Type
	{
		get { return _obstacleType; }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
