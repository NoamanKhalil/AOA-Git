using UnityEngine;
using System.Collections;

public class Selector : NodeCs {


	public override void currentBehaviour () 
	{
		foreach (NodeCs node in children) 
		{

			node.currentBehaviour (); 

			if (node.isSuccessful ()) {
				Succeed ();
				return;
			} 

			else if (node.isRunning ()) {
				
				Running (); 
				return; 

			} 

		}
	
		Fail (); 
		return; 

	}
}
