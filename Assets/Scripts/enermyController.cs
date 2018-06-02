using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
    //public Vector2 startPos;
    public GameObject enemy;
    public float speed;
    Rigidbody2D Rb;
    public GameObject bolt;
    public int shotWait;
    public int hasfire;
    public GameObject mat;
    // Use this for initialization
    void Start () {
        Rb = enemy.GetComponent<Rigidbody2D>();
        //Rb.position = startPos;
        Rb.velocity = speed*new Vector2(0,-1);
        if(hasfire==1)StartCoroutine(Fire());
    }
	
	// Update is called once per frame
	void Update () {
       // Fire();
	}
    void OnTriggerEnter2D(Collider2D other)
    {
    }
    IEnumerator Fire()
    {
        while(true)
        {
            Instantiate(bolt, Rb.transform);
            yield return new WaitForSeconds(shotWait);
        }
    }
    public void fireworks()
    {
        Instantiate(mat, transform);
        Destroy(gameObject);
    }
}
