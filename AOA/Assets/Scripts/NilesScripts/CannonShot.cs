using UnityEngine;
using System.Collections;

public class CannonShot : MonoBehaviour {

	public int cannonDamage;
	public int liveRoundCount;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision enemy)
	{
		if (enemy.gameObject.tag == "Enemy") 
		{
			enemy.gameObject.GetComponent<enemyController>().getAndTakeDamage(cannonDamage);
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		liveRoundCount++;
		if(liveRoundCount == 100)
		{
			Destroy (gameObject);
		}
	
	}
}
