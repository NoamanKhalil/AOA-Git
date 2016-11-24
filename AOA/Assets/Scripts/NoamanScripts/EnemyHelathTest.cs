using UnityEngine;
using System.Collections;

public class EnemyHelathTest : MonoBehaviour {

	public GameObject healBar ;
	public float maxHealth ;
	public float curHealth ;

	// Use this for initialization
	void Start ()
	{
		curHealth  = maxHealth ; 

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void decreaseHealth ()
	{
		curHealth-= 2.0f  ; 
			//if cur == 80/100 == 0.8f 
		float calHealth  = curHealth/ maxHealth ; 
		SetHealthBar (calHealth) ;  
	}


	public void SetHealthBar (float myhealth )
	{
		healBar.transform.localScale = new Vector3 (myhealth , healBar.transform.localScale.y,  healBar.transform.localScale.z) ;
	}

}
