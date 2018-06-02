using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public int playerNum = 0;
    public Vector2 startPos;
    public GameObject player;
    public float speed;
    public float angularSpeed;
    Rigidbody2D Rb;
    // Use this for initialization
    void Start () {
        Rb = player.GetComponent<Rigidbody2D>();
        Rb.position=startPos;
	}
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxis("Horizontal" + playerNum);
        float moveY= Input.GetAxis("Vertical" + playerNum);
        float rotateC = Input.GetAxis("Quaternion" + playerNum);
        if (rotateC==0&&(moveX!=0||moveY!=0))
        {
            Rb.freezeRotation = true;
        }
        else
        {
            Rb.freezeRotation = false;
        }
        Vector2 movement = new Vector2(moveX, moveY);
        Rb.velocity= movement.normalized*speed;
        Rb.angularVelocity = rotateC*angularSpeed;
        if (Input.GetButtonDown("Fire"+playerNum))
        {
            Fire();
        }
        
    }
    public void Fire()
    {
        //Instantiate();
        Debug.Log("Fire" + playerNum);
    }
}
