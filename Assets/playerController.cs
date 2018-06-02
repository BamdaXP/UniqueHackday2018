using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public int playerNum = 0;
    public Vector2 startPos;
    public GameObject player;
    public float speed;
    Rigidbody2D Rb;
    // Use this for initialization
    void Start () {
        Rb = player.GetComponent<Rigidbody2D>();
        Rb.position=startPos;
        Rb.velocity = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxis("Horizontal" + playerNum);
        float moveY= Input.GetAxis("Vertical" + playerNum);
        Vector2 movement = new Vector2(moveX, moveY);
        Rb.velocity= movement;
        if(Input.GetButtonDown("Fire"+playerNum))
        {
            Fire();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enermy"))
        {
            
        }
    }
    public void Fire()
    {
        //Instantiate();
        Debug.Log("Fire" + playerNum);
    }
}
