using UnityEngine;
using System;
using System.Collections;

public class Attack : NodeCs {

	public float closestDistance; 
	public GameObject closestTurret; 
	public bool inRange;
	public float tick = 300f;

	public override void currentBehaviour () 
	{


		//float distanceToTurret = Vector3.Distance(ownerTree.transform.position, closestTurret.transform.position);

		//Debug.Log ("attacknode");
		closestDistance = Mathf.Infinity;

		GameObject[] allTurrets = GameObject.FindGameObjectsWithTag ("Turret");

		foreach (GameObject turret in allTurrets) 
		{
			
			//Debug.Log ("Attack");
			float turretDistance = Vector3.Distance (turret.transform.position,ownerTree.transform.position); 
			//Debug.Log ("step2");

			if (turretDistance < closestDistance)
			{
				closestTurret = turret;
				closestDistance = turretDistance;
				//Debug.Log ("step 3");
				//turret.gameObject.GetComponent<TowerBehaviour>().getAndTakeDamage(ownerTree.GetComponent<enemyController>().enemyDamage);
			}

		}

		 

		float distanceToTurret = Vector3.Distance(ownerTree.transform.position, closestTurret.transform.position);

		if (distanceToTurret < 5)
		{
			ownerTree.GetComponent<enemyAnmationController>().onAttack();
			tick -= Time.time;
			if (tick <=0)
			{
			closestTurret.gameObject.GetComponent<TowerBehaviour>().getAndTakeDamage(ownerTree.GetComponent<enemyController>().enemyDamage);
		    tick = 300f ; 
			}
				
		}





	}
		


}



