using UnityEngine;
using System;
using System.Collections;

public class Attack : NodeCs {

	public float closestDistance; 
	public GameObject closestTurret; 
	public bool inRange;

	public override void currentBehaviour () 
	{



		Debug.Log ("attacknode");
		closestDistance = Mathf.Infinity;

		GameObject[] allTurrets = GameObject.FindGameObjectsWithTag ("Turret");

		foreach (GameObject turret in allTurrets) 
		{
			
			Debug.Log ("Attack");
			float turretDistance = Vector3.Distance (turret.transform.position,ownerTree.transform.position); 
			Debug.Log ("step2");

			if (turretDistance < closestDistance)
			{
				closestTurret = turret;
				closestDistance = turretDistance;
				Debug.Log ("step 3");
			}

		}

		if (ownerTree.transform.position == closestTurret.transform.position)
		{
			Debug.Log ("ATTACK");
		}





	}


}
