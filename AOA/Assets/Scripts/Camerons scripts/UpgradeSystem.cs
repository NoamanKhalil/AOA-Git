﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI ;
public enum TurretLevel
{
	Level0,
	Level1,
	Level2,
	Level3
}
public class UpgradeSystem : MonoBehaviour {

	public Text text ;
	public TurretLevel currentLevel; 
	private int currencyAvailable; 
	private int currencyNeeded = 1000;
	private int currencyNeededToBuild = 250 ; 
	public int repairCost = 250;
	public int levelCase = 1;
	public float turretHealth;
	public float fullHealth;
	public GameObject turret ; 

	private TowerBehaviour tow ; 

	void Start () {

		currentLevel = TurretLevel.Level0;  
		fullHealth = GetComponent<TowerBehaviour> ().totalTurretHealth;
		tow = GetComponent <TowerBehaviour>();
	}

	// Update is called once per frame
	void Update () {

		currencyAvailable = GameObject.Find("GameManager").GetComponent<GameManager> ().currency; 
		turretHealth = GetComponent<TowerBehaviour> ().currentTurretHealth;

		switch (levelCase)
		{
		case 0:
			currentLevel = TurretLevel.Level0;
			break; 

		case 1:
			currentLevel = TurretLevel.Level1;

			break;

		case 2:
			currentLevel = TurretLevel.Level2;

			break;

		case 3:
			currentLevel = TurretLevel.Level3;

			break;
		}

	}
		
	void OnTriggerStay(Collider col)
	{
		if (turret.active == true)
		{
			text.text = "Press \"E\" to upgrade turret\nCredits:"+currencyNeeded + " \n Press \"R\" to repair turret to full. \n Credits: 250"; 
			if (col.gameObject.tag == "Player") 
			{
				//Debug.Log ("triggered");
				//if (Input.GetKeyDown (KeyCode.E) && currencyAvailable >= currencyNeeded  && levelCase < 4)  
				if (Input.GetKeyUp (KeyCode.E) && levelCase < 4 && currencyAvailable >= currencyNeeded)  
				{
					GameObject.Find ("GameManager").GetComponent<GameManager> ().DeductCurrency(currencyNeeded);
					currencyNeeded += 500; 
					levelCase++;
					this.transform.GetComponent<TowerBehaviour> ().radius += 0.5f;
					this.transform.GetComponent<TowerBehaviour> ().fireRate -= 0.05f;
					this.transform.GetComponent<TowerBehaviour> ().damage += 0.5f;
//					Debug.Log (this.currentLevel);
//					Debug.Log (this.GetComponent<TowerBehaviour> ().radius);
//					Debug.Log (this.GetComponent<TowerBehaviour> ().fireRate);
//					Debug.Log (this.GetComponent<TowerBehaviour> ().damage);
					
				}
				else if(Input.GetKeyUp (KeyCode.R) && currencyAvailable >= repairCost && turretHealth <= fullHealth)
				{
					GameObject.Find ("GameManager").GetComponent<GameManager> ().DeductCurrency(repairCost);
					GetComponent<TowerBehaviour> ().RepairToFull(fullHealth);
				}
			}
		}
		if (turret.active == false)
		{
			text.text = "Credits:"+currencyNeededToBuild+"Build works !"; 
			    if (Input.GetKeyUp (KeyCode.E) && currencyAvailable >=currencyNeededToBuild )  
				{
					GameObject.Find ("GameManager").GetComponent<GameManager> ().DeductCurrency(currencyNeededToBuild);
				     tow.isEnabled = true ;
					turret.SetActive (true); 
					Debug.Log ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
				}
		
		}
	}
}
