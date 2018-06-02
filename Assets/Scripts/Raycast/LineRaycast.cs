using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRaycast : MonoBehaviour {
	
	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private LineRenderer _line;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 playerPosition = _player.transform.position;
			Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			direction.z = 0.0f;
			direction = (direction - playerPosition).normalized;
			Vector3 endPostion = GetLineEnd(playerPosition, direction);
			_line.SetPosition(0, playerPosition);
			_line.SetPosition(1, endPostion);
		}
	}

	// 直线射线在地图上的终点
	Vector3 GetLineEnd(Vector3 start, Vector3 direction)
	{
		float distance = 100;
		direction.Normalize();
		RaycastHit2D[] lineTest = Physics2D.RaycastAll(start, direction, distance);
		foreach (var hit in lineTest)
		{
			// if(hit.collider == null) continue;
			if (hit.collider.gameObject.CompareTag("Obstacle"))
			{
				ObstacleBase obstacle = hit.collider.gameObject.GetComponent<ObstacleBase>();
				if (obstacle.Type == ObstacleBase.ObstacleType.Glass) continue;
				else return hit.point;
			}
		}
		return start + direction * 100;
	}
}
