using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    public enum Scene {Title,Assemble,Level,GameOver};
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

    public void AssembleToLevel()
    {
        cover.SetBool("loading", true);
        LineManager manager = GameObject.Find("PlayerRayManager").GetComponent<LineManager>();
        DontDestroyOnLoad(manager.gameObject);
        LineRenderer lineOne = GameObject.Find("LineOne").GetComponent<LineRenderer>();
        LineRenderer lineTwo = GameObject.Find("LineTwo").GetComponent<LineRenderer>();
        int countOne = lineOne.positionCount, countTwo = lineTwo.positionCount;
        manager.lineOnePositions = new Vector3[countOne];
        manager.lineTwoPositions = new Vector3[countTwo];
        for (int i = 1; i < countOne; i++)
        {
            manager.lineOnePositions[i] = lineOne.GetPosition(i) - lineOne.GetPosition(0);
        }

        manager.lineOnePositions[0] = Vector3.zero;
        for (int i = 1; i < countTwo; i++)
        {
            manager.lineTwoPositions[i] = lineTwo.GetPosition(i) - lineTwo.GetPosition(0);
        }

        manager.lineTwoPositions[0] = Vector3.zero;
        StartCoroutine(LoadingAssembleToLevel());
    }
    public IEnumerator LoadingAssembleToLevel()
    {
        AsyncOperation o = SceneManager.LoadSceneAsync("Level");
        while (!o.isDone)
        {
            yield return null;
        }

        SceneManager.LoadScene("Level");
        scene = Scene.Level;
        cover.SetBool("loading", false);
    }

    public void ToOver()
    {
        cover.SetBool("loading", true);
        StartCoroutine(LoadingToOver());

    }
    public IEnumerator LoadingToOver()
    {
        Destroy(GameObject.Find("PlayerRayManager"));
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameOver");
        scene = Scene.GameOver;
        cover.SetBool("loading", false);
    }


    public void ToTitle()
    {
        cover.SetBool("loading", true);
        StartCoroutine(LoadingToTitle());

    }
    public IEnumerator LoadingToTitle()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Title");
        scene = Scene.Title;
        cover.SetBool("loading", false);
    }
}
