using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LineGenerator : SerializedMonoBehaviour {
    public class Point
    {
        public Point(float x, float y)
        {
            pos = new Vector3(x, y);
        }
        public Vector3 pos;
    }

    public LineRenderer line;

    public List<Point> points = new List<Point>();
    [ReadOnly]
    public List<Point> selectedPoints = new List<Point>();

    [Range(0.01f,0.99f)]
    public float connetSpeed = 0.2f;

    public int index = 0;
    public Point pointing { get { return points[index]; } }
    public bool finished {
        get
        {
            if (selectedPoints[selectedPoints.Count-1]!=points[points.Count-1])
            {
                return false;
            }
            return true;
        }
    }
    [ReadOnly]
    public bool processing = false;

    public Transform GeneratorCenter;
    public float radius;
    public int candidates;

    private void Awake()
    {
        points.Clear();
        switch (GameManager.Instance.level)
        {
            case 1:
                LevelOne();
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
        if (points.Count <= 0)
        {
            Debug.LogWarning("No Point Candidates!!");
            return;
        }

        selectedPoints.Clear();
        //Add the first point to the 
        selectedPoints.Add(points[0]);
        line.positionCount = 1;
        line.SetPosition(0, points[0].pos);
    }

    private void Update()
    {}

    private bool Connectable()
    {
        Point p = pointing;
        if (p==null)
        {
            return false;
        }
        foreach (var point in selectedPoints)
        {
            if (p == point)
            {
                return false;
            }
        }
        return true;
    }

    public void Connect()
    {
        if (!Connectable()||processing)
        {
            AudioManager.Instance.PlaySE("Warn");
            return;
        }
        AudioManager.Instance.PlaySE("Connect");
        StopAllCoroutines();
        line.SetPosition(line.positionCount - 1, selectedPoints[selectedPoints.Count - 1].pos);
        selectedPoints.Add(pointing);
        StartCoroutine(Connecting());
    }

    private IEnumerator Connecting()
    {
        processing = true;
        line.positionCount += 1;
        for (int i = 0; i <= 33; i++)
        {
            Vector3 v = Vector3.Lerp(line.GetPosition(line.positionCount - 2), selectedPoints[selectedPoints.Count - 1].pos, (float)i / 33);
            line.SetPosition(line.positionCount - 1, v);
            yield return null;
        }
        processing = false;
    }

    public void Cancel()
    {
        //Can not remove the begin
        if (selectedPoints.Count<=1||processing)
        {
            AudioManager.Instance.PlaySE("Warn");
            return;
        }
        AudioManager.Instance.PlaySE("Disconnect");
        selectedPoints.RemoveAt(selectedPoints.Count - 1);
        StopAllCoroutines();
        StartCoroutine(Cancelling());
    }
    private IEnumerator Cancelling()
    {
        processing = true;
        for (int i = 0; i <= 33; i++)
        {
            Vector3 v = Vector3.Lerp(line.GetPosition(line.positionCount - 1), selectedPoints[selectedPoints.Count - 1].pos, (float)i / 33);
            line.SetPosition(line.positionCount - 1, v);
            yield return null;
        }
        line.positionCount -= 1;
        processing = false;
    }

    private void LevelOne()
    {
        points.Add(new Point(1, 1));
        points.Add(new Point(2, 1));
        points.Add(new Point(3, 1));
        points.Add(new Point(1, 2));
        points.Add(new Point(2, 2));
        points.Add(new Point(3, 2));

    }
}

