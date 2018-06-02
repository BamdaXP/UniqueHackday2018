using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermyController : MonoBehaviour {
    public Vector2 startPos;
    public GameObject enermy;
    public float speed;
    Rigidbody2D Rb;
    public GameObject bolt;
    public int shotWait;
    // Use this for initialization
    void Start () {
        Rb = enermy.GetComponent<Rigidbody2D>();
        Rb.position = startPos;
        Rb.velocity = speed*new Vector2(0,-1);
        StartCoroutine(Fire());
    }
	
	// Update is called once per frame
	void Update () {
       // Fire();
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
    }
    IEnumerator Fire()
    {
        while(true)
        {
            Instantiate(bolt, Rb.transform);
            Debug.Log("fire");
            yield return new WaitForSeconds(shotWait);
        }

    }
}
