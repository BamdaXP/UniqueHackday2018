using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTitle : MonoBehaviour {

	void Start () {
        AudioManager.Instance.PlayBGM("Main");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.PlaySE("Confirm");
            GameManager.Instance.TitleToAssemble();
        }
	}
}
