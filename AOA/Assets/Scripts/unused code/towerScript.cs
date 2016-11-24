using UnityEngine;
using System.Collections;

public class towerScript : MonoBehaviour {
	
	
	public GameObject cannonPrefab; 
	public Transform player; 
	public Transform towerPrefab;
	public LayerMask towerMask;
	public float towerRadius = 4.0f; 
	public Collider[] isInRange; 
	public float fired = 0; 
	public float health; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//checks if collider is in range of transform. fired variable makes it so that the tower can only fire when the timer is at 0, this stops it from firing endlessly
		isInRange = Physics.OverlapSphere(towerPrefab.position, towerRadius);
		fired -= Time.deltaTime;


		//checks if there is a collider within range and if true, then fire.
		if (isInRange != null  &&  fired <= 0) 
		{
			if (isInRange[0].tag == "Enemy") {
				//Debug.Log(isInRange.transform.position);
				Vector3 direction = isInRange [0].transform.position - transform.position;
				GameObject cannon = Instantiate (cannonPrefab, transform.position, Quaternion.identity) as GameObject;
				cannon.GetComponent<Rigidbody> ().AddForce (direction.normalized * 20.0f, ForceMode.Impulse);
				fired = 1; 
			}
			
		}
		
	}
}
