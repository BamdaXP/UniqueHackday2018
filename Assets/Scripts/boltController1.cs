using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltController1 : MonoBehaviour {

    public float speed;
    public GameObject bolt;
	// Use this for initialization
	void Start () {
        bolt.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("enter");
        if (other.gameObject.CompareTag("Player")) Destroy(this);
    }
}
