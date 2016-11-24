using UnityEngine;
using System.Collections;

public class HealthCheck : NodeCs {

	GameObject player ;

	public override void currentBehaviour ()
	{
		
		if (ownerTree.GetComponent<enemyBehaviour>().health <= 50 && ownerTree.GetComponent<enemyBehaviour>().health > 10) 
		{
			Succeed ();
		}
		else
		{
			Fail ();
		}
	}
}
