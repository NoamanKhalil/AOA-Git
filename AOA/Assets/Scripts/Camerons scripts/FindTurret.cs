using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FindTurret : NodeCs
{
	public GameObject [] allTurrets; 
	public Vector3[] pathToFollow; 
	public Transform[] convertedPath;
	private int count; 
	public GameObject closestTurret = null; 
	public float closestDistance;
	public bool hasPath;
	public float attackRadius = 10f; 
	public LayerMask turretMask; 


	// Use this for initialization


	// Update is called once per frame

	public override void currentBehaviour()
	{
		/*if (instance == null) 
		{
			instance = new PathFinding();
		}*/

		//instance = new PathFinding ();
		
		closestDistance = Mathf.Infinity;

		Debug.Log ("Find Turret");
		
		allTurrets = GameObject.FindGameObjectsWithTag ("Turret");

		closestDistance = Mathf.Infinity;

			foreach (GameObject turret in allTurrets) 
		    {
				Debug.Log ("entry");
					float turretDistance = Vector3.Distance (turret.transform.position,ownerTree.transform.position); 
					Debug.Log ("step2");

				if (turretDistance < closestDistance) {
					
					closestTurret = turret;
					closestDistance = turretDistance;
					Debug.Log ("step 3");

				} 

				Collider [] targetsInRange  = Physics.OverlapSphere(ownerTree.transform.position, attackRadius, turretMask);

				if (targetsInRange != null) 
				{
					Succeed (); 
				}
				
		
			}
	
		PathFinding.instance.showMeTheWay (ownerTree.transform, closestTurret.transform);

		ownerTree.transform.position = Vector3.MoveTowards (ownerTree.transform.position, PathFinding.instance.tempArray[0], 5f * Time.deltaTime);
		//pathToFollow = instance.tempArray;
		//instance.showMeTheWay (ownerTree.transform, closestTurret.transform);
		//pathToFollow = instance.tempArray;

		//Debug.Log (instance.tempArray);

		//ownerTree.transform.position = Vector3.MoveTowards (ownerTree.transform.position, closestTurret.transform.position, 5f * Time.deltaTime); 
		/*foreach (Vector3 waypnt in pathToFollow)
		{
			//Vector3.MoveTowards(
			ownerTree.transform.position = Vector3.MoveTowards (ownerTree.transform.position, pathToFollow[count],5f );
			count++;
		}*/


		Debug.Log ("Step 4");

		if (ownerTree.transform.position == closestTurret.transform.position)
		{ 
			Debug.Log ("Step 5");
			Succeed ();
		}  


	}
//		Debug.Log (closestDistance);
}


		
	


