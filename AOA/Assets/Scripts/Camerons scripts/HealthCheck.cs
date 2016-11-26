using UnityEngine;
using System.Collections;

public class HealthCheck : NodeCs {

	GameObject player ;

	public override void currentBehaviour ()
	{
		
		if (ownerTree.GetComponent<enemyController>().currentEnemyHealth <= 50 && ownerTree.GetComponent<enemyController>().currentEnemyHealth > 10) 
		{
			Succeed ();
		}
		else
		{
			Fail ();
		}
	}
}
