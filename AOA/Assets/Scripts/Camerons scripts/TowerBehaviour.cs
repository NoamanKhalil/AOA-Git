using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TowerBehaviour : MonoBehaviour 
{	
	public Image healthBar;
	public GameObject projectile ; 
	public float radius = 20.0f;
	public LayerMask layermask ; 
	public float fireRate = 1.5F;
	private float nextFire = 0.0F;
	public float damage = 5f;
	public GameObject currentTarget; 
	public Transform rotatingPart;
	public float enemyDistance;
	public float lookRadius = 30.0f; 
	public int health; 
	public int totalEnemyHealth ;
	private Transform intRotation ; 

	// Use this for initialization
	void Start ()
	{
		intRotation = this.rotatingPart.transform ; 
		health = totalEnemyHealth ; 
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		healthBar.fillAmount = (float)health / totalEnemyHealth;
		//enemyDistance = Vector3.Distance (transform.position, currentTarget.transform.position); 
		Vector3 lookPosition = gameObject.transform.position; 
		Collider[] lookFor = Physics.OverlapSphere (lookPosition, lookRadius, layermask);

		if (lookFor.Length > 0) 
		{
			if (lookFor [0].tag == "Enemy") {

				currentTarget = lookFor[0].transform.gameObject;
				enemyDistance = Vector3.Distance (transform.position, currentTarget.transform.position); 

				Vector3 position = gameObject.transform.position; 

				Vector3 Direction = currentTarget.transform.position - transform.position;

				Quaternion lookAt = Quaternion.LookRotation (Direction);
				Vector3 Rotation = Quaternion.Lerp(rotatingPart.rotation,lookAt,Time.deltaTime * 0.2f).eulerAngles;
				rotatingPart.rotation = Quaternion.Euler (-90, Rotation.y, 0);
			}
		}
		 

		/*if (enemyDistance <= 30f) {

			Vector3 position = gameObject.transform.position; 

			Vector3 Direction = currentTarget.transform.position - transform.position;

			Quaternion lookAt = Quaternion.LookRotation (Direction);
			Vector3 Rotation = lookAt.eulerAngles;
			rotatingPart.rotation = Quaternion.Euler (-90, Rotation.y, 0);
		
		}*/
			onAttack (); 
		
	}
	void onAttack ()
	{
 
		Vector3 position = gameObject.transform.position ; 
		Collider []  something = Physics.OverlapSphere(position ,radius ,layermask ); 

		
		if (something.Length > 0 && Time.time > nextFire) {
			if (something [0].tag == "Enemy") {

				currentTarget = something [0].transform.gameObject;
				Debug.Log (something [0].transform);
				nextFire = Time.time + fireRate;
				Vector3 Direction = something[0].transform.position - transform.position;

		

				GameObject cannon = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
				cannon.GetComponent<Rigidbody> ().AddForce (Direction.normalized * 100.0f, ForceMode.Impulse);

			}
		}
	}
	public void getAndTakeDamage(int dmg)
	{
	totalEnemyHealth -= dmg;
	}




	/*void OnDrawGizmos ()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (transform.position, radius);
		Gizmos.DrawWireSphere (transform.position, lookRadius);
	}*/



	
}
