using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByBoundary : MonoBehaviour {

    // Use this for initialization
    public GameObject mat;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if(other.CompareTag("Enemy"))
        {
            //LoseBlood();
            Instantiate(mat, other.transform.position,other.transform.rotation);
        }
        Destroy(other.gameObject);
       // Debug.Log("1");
        
    }
}
