using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour
{

	private Animation anim ; 

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetMouseButtonDown (0))
		{
			
			anim.Play ("soldierFiring");

		}
		else if (Input.GetKey (KeyCode.A )  || Input.GetKey (KeyCode.S )|| Input.GetKey (KeyCode.D )|| Input.GetKey (KeyCode.W )   || Input.GetKey (KeyCode.RightArrow )|| Input.GetKey (KeyCode.LeftArrow )|| Input.GetKey (KeyCode.UpArrow )|| Input.GetKey (KeyCode.DownArrow ))
		{
			
			anim.Play ("soldierRun");
			
		}
		else 
		{
			if (anim.isPlaying)
			{
				anim.Stop ();
			}
			else 
			{
				anim.Play ("soldierIdle");
			}
		}

	}

}
