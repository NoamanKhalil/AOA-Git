using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Invoke ("destroy",1.2f);
	
	}
	void destroy ()
	{
		Destroy (this.gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
