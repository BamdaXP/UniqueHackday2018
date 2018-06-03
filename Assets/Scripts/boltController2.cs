using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltController2 : MonoBehaviour {

    public float speed;
    public GameObject bolt;
    public GameObject followed;
    public float followrate;
    Rigidbody2D boltbody, followedbody;
    Vector2 dir;
    bool left = true;
	// Use this for initialization
	void Start () {
        boltbody=bolt.GetComponent<Rigidbody2D>();
        followedbody=followed.GetComponent<Rigidbody2D>();
        dir = new Vector2(0,-1);
        boltbody.velocity = dir.normalized * speed;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = followedbody.position - boltbody.position;
        boltbody.rotation = Mathf.Atan(pos.y / pos.x) * 180 / Mathf.PI+90;
        boltbody.AddForce(pos.normalized*followrate*pos.magnitude/(boltbody.velocity.magnitude+1));
   
	}
    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("enter");
    }
}
