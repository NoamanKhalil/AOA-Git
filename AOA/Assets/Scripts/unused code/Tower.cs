using UnityEngine;
using System.Collections;
public class Tower : MonoBehaviour 
{		
	public GameObject cannonprefab ; 
	public float radius = 5.0f;
	public LayerMask layermask ; 
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	// Update is called once per frame
	void Update ()
	{
		onAttack () ; 
	}
	void onAttack ()
	{
		Vector3 position = gameObject.transform.position ; 
		Collider []  something = Physics.OverlapSphere(position ,radius ,layermask ); 

		if (something.Length > 0 && Time.time > nextFire)
		{
			if(something[0].tag == "Enemy"){
				nextFire = Time.time + fireRate;
				Vector3   Direction  = something[0].transform.position - transform.position ; 
				GameObject cannon = Instantiate (cannonprefab , transform.position , Quaternion.identity) as GameObject ;
				cannon.GetComponent<Rigidbody>().AddForce(Direction.normalized*5.0f, ForceMode.Impulse);

			}
		}
	}

}
