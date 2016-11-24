using UnityEngine;
using System.Collections;

public class FindPlayer : NodeCs {

	public GameObject player; 
	public override void currentBehaviour () 
	{

		/*if (instance != null) 
		{
			instance = new PathFinding(); 
		}*/
		Debug.Log ("in");
		player = GameObject.FindGameObjectWithTag ("Player"); 
		if (player != null) 
		{
			Debug.Log ("found player");

			PathFinding.instance.showMeTheWay (ownerTree.transform, player.transform);

			ownerTree.transform.position = Vector3.MoveTowards (ownerTree.transform.position, PathFinding.instance.tempArray [0], 5f * Time.deltaTime); 

			Succeed ();
		}
	}
}
