using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	public Scrollbar healthOne;

	public Scrollbar healthTwo;

	[SerializeField] 
	private playerController playerOne;

	[SerializeField] 
	private playerController playerTwo;
	
	// Update is called once per frame
	void Update ()
	{
        float demandOne = (float) playerOne.health / playerOne.maxHealth;
        float demandTwo = (float) playerTwo.health / playerTwo.maxHealth;



        healthOne.size = healthOne.size + (demandOne - healthOne.size) * 0.2f;
		healthTwo.size = healthTwo.size + (demandTwo - healthTwo.size) * 0.2f;
    }
}
