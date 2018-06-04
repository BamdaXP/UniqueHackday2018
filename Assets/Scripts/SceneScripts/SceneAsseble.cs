using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using TMPro;
public class SceneAsseble : SerializedMonoBehaviour {

    public GameObject startDot;
    public GameObject candidateDot;
    public GameObject endDot;
    
    public LineGenerator OneGen;
    public LineGenerator TwoGen;

    [ReadOnly]
    public List<GameObject> OneDots = new List<GameObject>();
    [ReadOnly]
    public List<GameObject> TwoDots = new List<GameObject>();

    public bool finished
    {
        get
        {
            if (OneGen.finished&&TwoGen.finished)
            {
                return true;
            }
            return false;
        }
    }
    private bool starting = false;

    private int count;

    private void Start()
    {
        DrawPoints();
        AudioManager.Instance.StopBGM("GameOver");
        AudioManager.Instance.StopBGM("Main");
        AudioManager.Instance.PlayBGM("Main");

    }

    private void Update()
    {
        InputUpdate();
        StateUpdate();
        CountUpdate();
        SetChooseAnim();
    }

    private void StartCount()
    {
        count = (int)(5 * (1.0/Time.deltaTime));
    }

    private void CountUpdate()
    {
        if (finished)
        {
            if (starting == false)
            {
                StartCount();
                starting = true;
            }
            if (count>0)
            {
                count -= 1;
            }
            if (count <= 0)
            {
                GameManager.Instance.AssembleToLevel();
            }
        }
        
    }

    private void StateUpdate()
    {
        TextMeshProUGUI one = GameObject.Find("StateOneText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI two = GameObject.Find("StateTwoText").GetComponent<TextMeshProUGUI>();

        one.text = "Link the line to the <color=\"red\">Red Point</color> to <color=\"green\">Prepare</color>";
        two.text = "Link the line to the <color=\"red\">Red Point</color> to <color=\"green\">Prepare</color>";

        if (OneGen.finished)
        {
            one.text = "<color=\"yellow\">Waiting for partner......</color>";
        }
        if (TwoGen.finished)
        {
            two.text = "<color=\"yellow\">Waiting for partner......</color>";
        }
        if (OneGen.finished&&TwoGen.finished)
        {
            one.text = "<color=\"green\">Starting game in " + (int)(count / (1.0 / Time.deltaTime));
            two.text = "<color=\"green\">Starting game in " + (int)(count / (1.0 / Time.deltaTime));
        }
        else
        {
            starting = false;
        }
    }

    private void InputUpdate()
    {
        if (!OneGen.finished)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                AudioManager.Instance.PlaySE("Normal");
                int i = OneGen.index;
                i += 1;
                if (i > OneGen.points.Count - 1)
                {
                    i = 0;
                }
                OneGen.index = i;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                AudioManager.Instance.PlaySE("Normal");
                int i = OneGen.index;
                i -= 1;
                if (i < 0)
                {
                    i = OneGen.points.Count - 1;
                }
                OneGen.index = i;
            }
        }
        if (!TwoGen.finished)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AudioManager.Instance.PlaySE("Normal");
                int i = TwoGen.index;
                i += 1;
                if (i > TwoGen.points.Count - 1)
                {
                    i = 0;
                }
                TwoGen.index = i;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AudioManager.Instance.PlaySE("Normal");
                int i = TwoGen.index;
                i -= 1;
                if (i < 0)
                {
                    i = TwoGen.points.Count - 1;
                }
                TwoGen.index = i;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OneGen.Connect();
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            TwoGen.Connect();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OneGen.Cancel();
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            TwoGen.Cancel();
        }
    }

    private void DrawPoints()
    {
        Transform oneTr = GameObject.Find("DotOne").transform;
        Transform twoTr = GameObject.Find("DotTwo").transform;
        for (int i = 0; i < OneGen.points.Count; i++)
        {
            if (i==0)
            {
                GameObject o = Instantiate(startDot, oneTr);
                o.transform.Translate(OneGen.points[i].pos);
                OneDots.Add(o);
            }
            else if (i==OneGen.points.Count-1)
            {
                GameObject o = Instantiate(endDot, oneTr);
                o.transform.Translate(OneGen.points[i].pos);
                OneDots.Add(o);
            }
            else
            {
                GameObject o = Instantiate(candidateDot, oneTr);
                o.transform.Translate(OneGen.points[i].pos);
                OneDots.Add(o);
            }
        }

        for (int i = 0; i < TwoGen.points.Count; i++)
        {
            if (i == 0)
            {
                GameObject o = Instantiate(startDot, twoTr);
                o.transform.Translate(TwoGen.points[i].pos);
                TwoDots.Add(o);
            }
            else if (i == TwoGen.points.Count - 1)
            {
                GameObject o = Instantiate(endDot, twoTr);
                o.transform.Translate(TwoGen.points[i].pos);
                TwoDots.Add(o);
            }
            else
            {
                GameObject o = Instantiate(candidateDot, twoTr);
                o.transform.Translate(TwoGen.points[i].pos);
                TwoDots.Add(o);
            }
        }
    }

    private void SetChooseAnim()
    {
        for (int i = 0; i < OneDots.Count; i++)
        {
            if (i==OneGen.index)
            {
                OneDots[i].GetComponentInChildren<Animator>().SetBool("choosing",true);
            }
            else
            {
                OneDots[i].GetComponentInChildren<Animator>().SetBool("choosing", false);
            }
        }
        for (int i = 0; i < TwoDots.Count; i++)
        {
            if (i == TwoGen.index)
            {
                TwoDots[i].GetComponentInChildren<Animator>().SetBool("choosing", true);
            }
            else
            {
                TwoDots[i].GetComponentInChildren<Animator>().SetBool("choosing", false);
            }
        }
    }
}
