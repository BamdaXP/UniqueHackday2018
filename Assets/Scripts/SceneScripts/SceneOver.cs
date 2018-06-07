using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOver : MonoBehaviour {

    public float seconds = 5;
	// Use this for initialization
	void Start () {
        AudioManager.Instance.StopBGM("Assemble");
        AudioManager.Instance.PlayBGM("GameOver");
        StartCoroutine(Waiting());
	}


    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(seconds);
        GameManager.Instance.TitleToAssemble();
    }

    
}
