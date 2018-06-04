using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
	public playerController player1;

	public playerController player2;

	public List<GameObject> indicators;
	
	// Use this for initialization
	void Start () {
        AudioManager.Instance.StopBGM("Main");
        AudioManager.Instance.PlayBGM("Assemble");
	}
	
	// Update is called once per frame
	void Update () {

        
		if (player1.IsFiring && player2.IsFiring)
		{
			var crossPoints = player1.Ray.GetIntersections(player2.Ray);
			for(int i=0; i<crossPoints.Count; i++)
			{
				indicators[i].SetActive(true);
				indicators[i].transform.position = crossPoints[i];
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, crossPoints[i]);
				if(hit != null && hit.collider != null)
				{
					if (hit.collider.gameObject.CompareTag("Enemy") == false) continue;
					hit.collider.gameObject.GetComponent<enemyController>().fireworks();
					Debug.Log("Hit");
				}
			}

			for (int i = crossPoints.Count; i < indicators.Count; i++)
			{
				indicators[i].SetActive(false);
			}

            if (crossPoints.Count>0)
            {
                GameObject.Find("Player1").GetComponentInChildren<LineRenderer>().endColor = new Color(70, 70, 200);
                GameObject.Find("Player2").GetComponentInChildren<LineRenderer>().endColor = new Color(70, 70, 200);
            }
            else
            {
                GameObject.Find("Player1").GetComponentInChildren<LineRenderer>().endColor = Color.white;
                GameObject.Find("Player2").GetComponentInChildren<LineRenderer>().endColor = Color.white;
            }
		}
		else
		{
			for (int i = 0; i < indicators.Count; i++)
			{
				indicators[i].SetActive(false);
			}
		}
	}
}
