using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    public enum Scene {Title,Assemble,Game};

    public int level = 1;

    public Scene scene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void TitleToAssemble()
    {
        SceneManager.LoadScene("Assemble");
    }
}
