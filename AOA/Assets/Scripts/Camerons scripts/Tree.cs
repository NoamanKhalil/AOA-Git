using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	 NodeCs Root;
	public static PathFinding instance; 
	public float tick = 0.5f;

	// Use this for initialization
	void Start () {

		/*if (instance == null) 
		{
			instance = new PathFinding (); 
		} 
		else 
		{
			Destroy (this); 
		}*/
			
		Root = new Selector (); 

		Root.AddChild (new Sequence ());
		Root.AddChild (new Sequence ());
		Root.AddChild (new Sequence ()); 

		Root.children [0].AddChild (new HealthCheck ());
		Root.children [0].AddChild (new FindPlayer ());
		Root.children [0].AddChild (new AttackPlayer ()); 
		Root.children [1].AddChild (new FindTurret ()); 
		Root.children [1].AddChild (new Attack ()); 
		Root.children [2].AddChild(new FleaCheck()); 
		Root.children [2].AddChild (new Flea ()); 



		Root.ownerTree = this;
		Root.children [0].ownerTree = this;
		Root.children [1].ownerTree = this;
		Root.children [2].ownerTree = this;
		Root.children [0].children [0].ownerTree = this;
		Root.children [0].children [1].ownerTree = this;
		Root.children [0].children[2].ownerTree  = this;
		Root.children [1].children [0].ownerTree = this;
		Root.children [1].children [1].ownerTree = this;
		Root.children [2].children [0].ownerTree = this;
		Root.children [2].children [1].ownerTree = this;
	
	

	}

	// Update is called once per frame
	void Update ()
	{
		tick -= Time.time;

		if (tick <= 0) 
		{
			
			Root.currentBehaviour ();
			tick = 0.5f;
		}

	}
}
