using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    public enum Scene {Title,Assemble,Game};
    public Scene scene;
    public int level = 1;

    public Animator cover;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    public void TitleToAssemble()
    {
        cover.SetBool("loading", true);
        StartCoroutine(LoadingTitleToAssemble());

    }
    public IEnumerator LoadingTitleToAssemble()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Assemble");
        scene = Scene.Assemble;
        cover.SetBool("loading", false);
    }
}
