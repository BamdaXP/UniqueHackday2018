using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour {

    public int playerNum = 0;
    public Vector2 startPos;
    public GameObject player;
    public float speed;
    private float sptmp;
    public float angularSpeed;
    public float minX, minY, maxX, maxY;
    Rigidbody2D Rb;

    [SerializeField]
    private PlayerRay _ray;
    public float _fireDuration = 1.0f;
    [SerializeField] 
    private float _fireRemaining;
    [SerializeField] 
    private bool _isFiring;

    public PlayerRay Ray
    {
        get { return _ray; }
    }

    public bool IsFiring
    {
        get { return _isFiring; }
    }

    public int health;
    public int maxHealth = 10;

    // Use this for initialization
    void Start () {
        Rb = player.GetComponent<Rigidbody2D>();
        Rb.position=startPos;

        _ray = player.GetComponentInChildren<PlayerRay>();
        _ray.gameObject.SetActive(false);
        _fireRemaining = 0.0f;
        _isFiring = false;
        health = maxHealth;

        sptmp = speed;
    }
	
	// Update is called once per frame
	void Update () {
        float moveX = Input.GetAxis("Horizontal" + playerNum);
        float moveY= Input.GetAxis("Vertical" + playerNum);
        float rotateC = Input.GetAxis("Quaternion" + playerNum);

        if (IsFiring)
        {
            speed = sptmp / 2;
        }
        else
        {
            speed = sptmp;
        }

        /*
        if (rotateC==0&&(moveX!=0||moveY!=0))
        {
            Rb.freezeRotation = true;
        }
        else
        {
            Rb.freezeRotation = false;
        }*/
        Vector2 movement = new Vector2(moveX, moveY);
        Rb.velocity= movement.normalized*speed;
        Rb.angularVelocity = rotateC*angularSpeed;
        if (Input.GetButtonDown("Fire"+playerNum))
        {
            Fire();
        }
        Rb.position = new Vector2(Mathf.Clamp(Rb.position.x, minX, maxX), Mathf.Clamp(Rb.position.y, minY, maxY));
	    if (_isFiring)
	    {
	        _fireRemaining -= Time.deltaTime;
	        if (_fireRemaining < 0.001f)
	        {
	            PostFire();
	        }
	    }
    }
    public void Fire()
    {
        //Instantiate();
        _ray.gameObject.SetActive(true);
        _isFiring = true;
        _fireRemaining = _fireDuration;
        // Debug.Log("Fire" + playerNum);
    }

    public void PostFire()
    {
        _ray.gameObject.SetActive(false);
        _isFiring = false;
        _fireRemaining = 0.0f;
        // Debug.Log("Post Fire" + playerNum);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy") && 
            !other.gameObject.CompareTag("Bolt")) return;
        health--;

        Camera.main.gameObject.GetComponent<Shaker>().Shake(0.5f);

        AudioManager.Instance.PlaySE("WeHurt");
        if (health<=0)
        {
            GameManager.Instance.ToOver();
        }
    }

    
}
