using UnityEngine;
using System.Collections;

public class Flea : NodeCs {


	public float closestSpawn = Mathf.Infinity;
	public bool hasPath;


	public override void currentBehaviour () 
	{
		GameObject fleaLocation = GameObject.FindGameObjectWithTag ("FleaTo");
			
		PathFinding.instance.showMeTheWay (ownerTree.transform, fleaLocation.transform);
		ownerTree.transform.position = Vector3.MoveTowards (ownerTree.transform.position, PathFinding.instance.tempArray[0], 15f * Time.deltaTime);


	}
	}
	