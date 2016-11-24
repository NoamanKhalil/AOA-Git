using UnityEngine;
using System.Collections;

public class FleaCheck : NodeCs {

	public override void currentBehaviour () 
	{
		if (ownerTree.GetComponent<enemyBehaviour> ().health <= 10) {
			Succeed ();
		}
		else 
		{
			Fail (); 
		}
	}
}
