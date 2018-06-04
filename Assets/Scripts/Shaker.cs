using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour {
    [SerializeField]
    private bool shaking = false;
    public float intense=0.1f;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (shaking)
        {
            Vector3 v = new Vector3(transform.position.x + Random.Range(-intense, intense),transform.position.y + Random.Range(-intense, intense),transform.position.z);
            transform.position = v;
        }
	}

    public void Shake(float time)
    {
        shaking = false;
        StopAllCoroutines();
        StartCoroutine(Shaking(time));
    }
    private IEnumerator Shaking(float time)
    {
        shaking = true;
        yield return new WaitForSeconds(time);
        shaking = false;
    }
}
