using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayConnectionDetect: MonoBehaviour
{
	public PlayerRay ray1;

	public PlayerRay ray2;
	[SerializeField]
	public GameObject[] indicator;
	
	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private LineRenderer _line;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Vector3 playerPosition = _player.transform.position;
			Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			direction.z = 0.0f;
			direction = (direction - playerPosition).normalized;
			_line.gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
			int _i, _j;
			var result = ray2.GetIntersections(ray1, out _i, out _j);
			for(int i=0; i<result.Count; i++)
			{
				indicator[i].transform.position = result[i];
			}
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

		return start + direction * 3;
	}
}
