using UnityEngine;
using System.Collections;

public class AlwaysSuccess : NodeCs {


	public override void currentBehaviour () 
	{
		this.children [0].currentBehaviour ();
		Succeed ();
	}


}
