﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().velocity /= 2;
    }
}
