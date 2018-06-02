using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
	// Use this for initialization
	private LineRenderer line;
	[SerializeField]
	private Vector2[] _points;
	private int _pointCount;

	void Start()
	{
	}

	private void LateUpdate()
	{
		line = gameObject.GetComponent<LineRenderer>();
		_points = new Vector2[line.positionCount];
		_pointCount = line.positionCount; 
		for (int i = 0; i < line.positionCount; i++)
		{
			_points[i].x = gameObject.transform.position.x + (gameObject.transform.localToWorldMatrix*line.GetPosition(i)).x;
			_points[i].y = gameObject.transform.position.y + (gameObject.transform.localToWorldMatrix*line.GetPosition(i)).y;
		}
	}

	public List<Vector2> GetIntersections(PlayerRay playerRay)
	{
		List<Vector2> results = new List<Vector2>();
		for (int i = 0; i < _pointCount-1; i++)
		{
			for (int j = 0; j < playerRay._pointCount-1; j++)
			{
				Vector2 intersection = new Vector2();
				if (GetIntersection(_points[i], _points[i + 1], playerRay._points[j], playerRay._points[j + 1], ref intersection))
				{
					results.Add(intersection);
				}
			}
		}

		return results;
	}
	
	bool GetIntersection(Vector2 a,Vector2 b, Vector2 c, Vector2 d, ref Vector2 outIntersection)
	{
		if ((c.x - d.x) * (a.y - b.y) - (a.x - b.x) * (c.y - d.y) < 0.001f && (c.x - d.x) * (a.y - b.y) - (a.x - b.x) * (c.y - d.y) > -0.001f) return false;
		Vector2 intersection = new Vector3();
		float scaler;
		intersection.x = ((a.x - b.x) * (c.x * d.y - d.x * c.y) - (c.x - d.x) * (a.x * b.y - b.x * a.y)) / ((c.x - d.x) * (a.y - b.y) - (a.x - b.x) * (c.y - d.y));  
		intersection.y = ((a.y - b.y) * (c.x * d.y - d.x * c.y) - (c.y - d.y) * (a.x * b.y - b.x * a.y)) / ((c.x - d.x) * (a.y - b.y) - (a.x - b.x) * (c.y - d.y));

		scaler = (intersection.x - a.x) / (b.x - a.x);
		if (scaler < 0.001f || scaler > 1.001f) return false;
		scaler = (intersection.x - c.x) / (d.x - c.x);
		if (scaler < 0.001f || scaler > 1.001f) return false;
		scaler = (intersection.y - a.y) / (b.y - a.y);
		if (scaler < 0.001f || scaler > 1.001f) return false;
		scaler = (intersection.y - c.y) / (d.y - c.y);
		if (scaler < 0.001f || scaler > 1.001f) return false;
		outIntersection = intersection;
		return true;
	}  
}
