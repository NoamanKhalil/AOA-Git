using UnityEngine;
using System.Collections;

public class AttackPlayer : NodeCs {

	public override void currentBehaviour ()
	{
		Debug.Log ("Attack");
		Succeed ();
	}
}
