using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopmovingTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy3"))
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
