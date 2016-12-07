using UnityEngine;
using System.Collections;

public class enemyAnmationController : MonoBehaviour {

	Animator anim ; 

	AnimatorStateInfo currentbaseState ;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent <Animator> (); 
 	}
	
	// Update is called once per frame
	void Update ()
	{
		currentbaseState = this.anim.GetCurrentAnimatorStateInfo (0);
	}

	public void onAttack ()
	{
		anim.SetInteger ("Anim" ,  1);
	}
	public void onWalk ()
	{
		anim.SetInteger ("Anim"  ,  0);
	}
	public void onDie ()
	{
		anim.SetInteger ("Anim" ,  2);
	}
}
