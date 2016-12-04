using UnityEngine;
using System.Collections;

public class Flea : NodeCs {


	public float closestSpawn = Mathf.Infinity;
	public bool hasPath;
	public Vector3 [] pathtoFollow ;
	Vector3 fleeDirection;
	Vector3 enemyRotation;
	Quaternion faceTowards;

	public override void currentBehaviour () 
	{
		GameObject fleaLocation = GameObject.FindGameObjectWithTag ("Ship");
			

		pathtoFollow = PathFinding.instance.showMeTheWay (ownerTree.transform, fleaLocation.transform);

		fleeDirection = fleaLocation.transform.position - ownerTree.transform.position;
		faceTowards = Quaternion.LookRotation(fleeDirection);
		enemyRotation = faceTowards.eulerAngles;
		ownerTree.transform.rotation = Quaternion.Euler(0, enemyRotation.y, 0);	

		if (pathtoFollow[0] != pathtoFollow [pathtoFollow.Length-1])
		{
			ownerTree.transform.position = Vector3.MoveTowards (ownerTree.transform.position, pathtoFollow [0], 5f *Time.deltaTime);
		}



	}
	}
	