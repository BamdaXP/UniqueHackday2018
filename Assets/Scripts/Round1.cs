using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round1 : MonoBehaviour {

    public GameObject[] enermies;
    public int waveNum,waveWidth;
    public int roundNum;
    public float deltaTime,length,firstTime;
    public int[,,] everyWave ={
        {
            {0,0,0,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,3,3,3,3,3,3,3,3,3,0,0},
            {0,0,3,0,0,0,0,0,0,0,3,0,0},
            {0,0,3,0,0,0,0,0,0,0,3,0,0},
            {0,0,3,0,0,0,0,0,0,0,3,0,0},
            {0,0,3,0,0,0,0,0,0,0,3,0,0},
            {0,0,3,0,0,0,0,0,0,0,3,0,0},
            {0,0,3,3,3,3,3,3,3,3,3,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
        },
        {
            {0,0,0,0,0,1,1,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,2,0,0,0,0,0,0,0,2,0,0},
            {0,0,2,0,0,0,0,0,0,0,2,0,0},
            {0,0,2,0,0,1,1,1,0,0,2,0,0},
            {0,0,2,0,0,0,0,0,0,0,2,0,0},
            {0,0,2,0,0,0,3,0,0,0,2,0,0},
            {0,0,2,0,0,0,0,0,0,0,2,0,0},
            {0,0,2,0,0,1,1,1,0,0,2,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
        },
        {
            {0,0,0,0,0,1,1,1,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,0,0,0,1,0,0,0,0},
            {0,0,0,1,2,1,0,1,2,1,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,1,1,2,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,1,0,0,0,0,0,0},
            {0,0,0,0,1,1,1,1,1,0,0,0,0},
            {0,0,0,0,0,1,1,1,0,0,0,0,0},
            {0,0,0,0,0,0,1,0,0,0,0,0,0},
        },
     
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
        yield return new WaitForSeconds(firstTime);
        while(true)
        {
            float currentDelta = deltaTime;
            for (int i = 0; i < waveNum; i++)
            {
                for (int j = 0; j < waveWidth; j++)
                {
                    int chooseRound = Mathf.FloorToInt(Random.Range(0, 3));
                    if (everyWave[chooseRound, i, j] != 0)
                    {
                        Instantiate(enermies[everyWave[chooseRound, i, j] - 1], new Vector3((j - waveWidth / 2) * length, transform.position.y, 0), Quaternion.identity);
                    }
                }
                yield return new WaitForSeconds(currentDelta);
                currentDelta = currentDelta * 0.95f;
            }
        }
        
    }
}
