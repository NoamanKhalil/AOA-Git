using UnityEngine;
using System.Collections;

public class Sequence : NodeCs {


	public override void currentBehaviour ()
	{

		foreach (NodeCs node in children) 
		{

			node.currentBehaviour ();

			if (node.hasFailed ()) 
			{
				Fail (); 
				return; 
			} 

			else if (node.isRunning ()) {
				Running ();
				return; 
			} 


		}

		Succeed (); 
		return;

	
	}
}
