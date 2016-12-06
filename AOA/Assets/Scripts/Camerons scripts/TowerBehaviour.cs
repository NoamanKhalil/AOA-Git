using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TowerBehaviour : MonoBehaviour 
{	
	public GameObject healthBar;
	public GameObject projectile ; 
	public float radius = 20.0f;
	public LayerMask layermask ; 
	public Transform muzzle;
	public float fireRate = 1.5F;
	private float nextFire = 0.0F;
	public float damage = 5f;
	public GameObject currentTarget; 
	public Transform rotatingPart;
	public float enemyDistance;
	public float lookRadius = 30.0f; 
	public float health; 
	public float currentTurretHealth ;
	public float totalTurretHealth ;
	public float healthPercentage ;
	private Transform intRotation ;
	private GameObject gm ; 
	Renderer rend ; 
	// Use this for initialization
	void Start ()
	{
		gm= GameObject.Find ("GameManager");
		intRotation = this.rotatingPart.transform ;
		totalTurretHealth = 100;
		currentTurretHealth = totalTurretHealth;
		health = currentTurretHealth ;
		rend =  healthBar.GetComponent<Renderer>(); 
	}
	// Update is called once per frame
	void  Update ()
	{
		healthPercentage =  currentTurretHealth/totalTurretHealth; 
		rend.material.color = Color.Lerp (Color.red ,Color.green , healthPercentage );
		//healthBar.fillAmount = (float)health / totalEnemyHealth;
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
				Vector3 Rotation = Quaternion.Lerp(rotatingPart.rotation,lookAt,Time.deltaTime * 2f).eulerAngles;
				//rotatingPart.rotation = Quaternion.Euler (90, Rotation.y, 0);
				rotatingPart.rotation = Quaternion.Euler (-90, Rotation.y, 0);
			}
		}
		onAttack (); 
		if (currentTurretHealth <=0 )
		{
			//Destroy(this.gameObject) ; 


		}
		
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

		

				GameObject cannon = Instantiate (projectile, muzzle.position, Quaternion.identity) as GameObject;
				cannon.GetComponent<Rigidbody> ().AddForce (Direction.normalized * 100.0f, ForceMode.Impulse);

			}
		}
	}
	public void getAndTakeDamage(int dmg)
	{
	currentTurretHealth -= dmg;
	}
	void OnTriggerEnter (Collider other )
	{
		if (other.tag == "Player")
		{
			if (gm.GetComponent<GameManager>().upgradeButtonNormal.activeSelf == false)
			{
				gm.GetComponent<GameManager>().activateUpgradeButton ();
				Debug.Log ("Canvas is enabled ");
			}
		}
	
	}
	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			if (gm.GetComponent<GameManager>().upgradeButtonNormal.activeSelf == true)
			{
			gm.GetComponent<GameManager>().activateUpgradeButton ();
			}
		}
	}

	public void RepairToFull(float repairCap)
	{
		currentTurretHealth = repairCap;
	}


	/*void OnDrawGizmos ()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (transform.position, radius);
		Gizmos.DrawWireSphere (transform.position, lookRadius);
	}*/



	
}
