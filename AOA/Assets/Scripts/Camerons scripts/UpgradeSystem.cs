using UnityEngine;
using System.Collections;

public enum TurretLevel
{
	Level0,
	Level1,
	Level2,
	Level3
}
public class UpgradeSystem : MonoBehaviour {

	public TurretLevel currentLevel; 
	private int currencyAvailable; 
	private int currencyNeeded = 1000;
	public int levelCase = 1;
	// Use this for initialization
	void Start () {

		currentLevel = TurretLevel.Level0;  
		Debug.Log (currentLevel);
	}
	
	// Update is called once per frame
	void Update () {

		currencyAvailable = GetComponent<GameManager> ().currency; 

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
		if (col.gameObject.tag == "Player") 
		{
			Debug.Log ("triggered");
			//if (Input.GetKeyDown (KeyCode.E) && currencyAvailable >= currencyNeeded  && levelCase < 4)  
			if (Input.GetKeyDown (KeyCode.E) && levelCase < 4)  
			{
				currencyAvailable -= 1000; 
				currencyNeeded += 500; 
				levelCase++;
				this.transform.GetComponent<TowerBehaviour> ().radius += 5;
				this.transform.GetComponent<TowerBehaviour> ().fireRate -= 0.5f;
				this.transform.GetComponent<TowerBehaviour> ().damage += 5;
				Debug.Log (this.currentLevel);
				Debug.Log (this.GetComponent<TowerBehaviour> ().radius);
				Debug.Log (this.GetComponent<TowerBehaviour> ().fireRate);
				Debug.Log (this.GetComponent<TowerBehaviour> ().damage);
				
			}
		}
	}
}
