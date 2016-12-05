using UnityEngine;
using System.Collections;

public class AttackPlayer : NodeCs {

	public float tick = 75f;

	public override void currentBehaviour ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		float distanceToPlayer = Vector3.Distance (ownerTree.transform.position, player.transform.position);  
		if (distanceToPlayer < 5)
		{

			tick -= Time.time;
			if (tick <=0)
			{
				player.gameObject.GetComponent<PlayerOperator>().getAndTakeDamage(ownerTree.GetComponent<enemyController>().enemyDamage);
				tick = 75f ; 
			}
			else 
			{
				Running ();
			}

		}

		Debug.Log ("Attack");
	}
}
