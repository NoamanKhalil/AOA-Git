using UnityEngine;
using System.Collections;

public class CannonShot : MonoBehaviour {

	public int cannonDamage;
	public int liveRoundCount;
	public ParticleSystem particleSys ; 
	// Use this for initialization
	void Awake ()
	{
		particleSys = GetComponentInChildren<ParticleSystem>();
	}

	void OnCollisionEnter(Collision enemy)
	{
		if (enemy.gameObject.tag == "Enemy") 
		{
			enemy.gameObject.GetComponent<enemyController>().getAndTakeDamage(cannonDamage);
			particleSys.Play();
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		liveRoundCount++;
		if(liveRoundCount == 50)
		{
			Destroy (gameObject);
		}
	
	}
}
