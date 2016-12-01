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

	Vector3 turretDirection;
	Vector3 enemyRotation;
	Quaternion faceTowards;

	public override void currentBehaviour()
	{
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

//				Collider [] targetsInRange  = Physics.OverlapSphere(ownerTree.transform.position, attackRadius, turretMask);
//
//				if (targetsInRange != null) 
//				{
//					Succeed (); 
//				}
				
		
			}

		pathToFollow = PathFinding.instance.showMeTheWay  (ownerTree.transform, closestTurret.transform);
		//Debug.Log(pathToFollow[0]);
//		for (int i = 1; i < pathToFollow.Length; i++) {
//			Debug.DrawLine(pathToFollow[i-1],pathToFollow[i]);



		turretDirection = closestTurret.transform.position - ownerTree.transform.position;
		faceTowards = Quaternion.LookRotation(turretDirection);
		enemyRotation = faceTowards.eulerAngles;
		ownerTree.transform.rotation = Quaternion.Euler(0, enemyRotation.y, 0);

		if (pathToFollow[0] != pathToFollow [pathToFollow.Length-1])
		{
		 ownerTree.transform.position = Vector3.MoveTowards (ownerTree.transform.position, pathToFollow [0], 5f *Time.deltaTime);
		}

	
		Debug.Log ("Step 4");

		if (ownerTree.transform.position == closestTurret.transform.position)
		{ 
			Debug.Log ("Step 5");
			Succeed ();
		}  



	}
//		Debug.Log (closestDistance);
}


		
	


