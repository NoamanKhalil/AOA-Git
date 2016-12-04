using UnityEngine;
using System.Collections;

public class FleaCheck : NodeCs {

	public override void currentBehaviour () 
	{
		if (ownerTree.GetComponent<enemyController> ().currentEnemyHealth <= 25) {
			Succeed ();
		}
		else 
		{
			Fail (); 
		}
	}
}
