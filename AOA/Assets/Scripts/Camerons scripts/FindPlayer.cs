﻿using UnityEngine;
using System.Collections;

public class FindPlayer : NodeCs {

	public Vector3 [] pathToFollow ;
	Vector3 playerDirection;
	Vector3 enemyRotation;
	Quaternion faceTowards;

	public GameObject player; 
	public override void currentBehaviour () 
	{

		/*if (instance != null) 
		{
			instance = new PathFinding(); 
		}*/
		//Debug.Log ("in");
		player = GameObject.FindGameObjectWithTag ("Player"); 
		if (player != null) 
		{
			//Debug.Log ("found player");

				
			pathToFollow = PathFinding.instance.showMeTheWay (ownerTree.transform, player.transform);

			playerDirection = player.transform.position - ownerTree.transform.position;
			faceTowards = Quaternion.LookRotation(playerDirection);
			enemyRotation = faceTowards.eulerAngles;
			  ownerTree.transform.rotation = Quaternion.Euler(0, enemyRotation.y, 0);	

			if (pathToFollow[0] != pathToFollow [pathToFollow.Length-1])
			{
				ownerTree.GetComponent<enemyAnmationController>().onWalk();
				ownerTree.transform.position = Vector3.MoveTowards (ownerTree.transform.position, pathToFollow [0], 5f *Time.deltaTime);
			}


			Succeed ();
		}
	}
}
