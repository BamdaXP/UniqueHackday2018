using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour {

    public LineGenerator gen;
    public float speed = 0.2f;
    private Vector3 tarPosition;

    private void Start()
    {
        transform.position = gen.points[gen.index].pos;
        tarPosition = gen.points[gen.index].pos;
    }

    private void Update()
    {
        tarPosition = gen.points[gen.index].pos;

        
        Vector3 newTrans = Vector3.Lerp(transform.localPosition, tarPosition, speed);
        transform.localPosition = newTrans;
    }
}
