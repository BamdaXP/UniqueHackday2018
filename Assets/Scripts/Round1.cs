using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round1 : MonoBehaviour {

    public GameObject[] enermies;
    public int waveNum,waveWidth;
    public float deltaTime,length;
    int[,] everyWave ={
            {0,0,1,1,1,0,0},
            {0,0,0,0,0,0,0},
            {0,1,0,0,0,1,0},
            {1,2,1,0,1,2,1},
            {0,0,0,0,0,0,0},
            {0,1,1,2,1,1,0},
            {0,0,0,0,0,0,0},
            {0,0,0,1,0,0,0},
            {0,1,1,1,1,1,0},
            {0,0,1,1,1,0,0},
            {0,0,0,1,0,0,0},
        };
	// Use this for initialization
	void Start () {
        StartCoroutine(Fire());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Fire()
    {
        for(int i=0;i<waveNum;i++)
        {
            for(int j=0;j<7;j++)
            {
                if(everyWave[i,j]!=0)
                {
                    Instantiate(enermies[everyWave[i, j] - 1], new Vector3((j - waveWidth/2) * length, transform.position.y, 0), Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(deltaTime);
        }
    }
}
