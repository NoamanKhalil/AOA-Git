using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class NodeCs {


	public List <NodeCs> children = new List<NodeCs>();
	public Tree ownerTree; 
	State state; 
	enum State 
	{
		Failure,
		Success, 
		Running
	}
	// Use this for initialization

	public virtual void currentBehaviour()
	{

	}

	public NodeCs()
	{
		
	}

	public NodeCs (Tree owner)
	{
		ownerTree = owner; 
	}
		
	public void Succeed ()
	{
		state = State.Success;
		Debug.Log ( this.GetType().ToString()+ "successful");
	}

	public void Fail()
	{
		state = State.Failure;
		Debug.Log ( this.GetType().ToString()+ "Failed");

	}

	public void Running ()
	{
		state = State.Running;
		Debug.Log ( this.GetType().ToString()+ "Running");

	}

	public void AddChild (NodeCs node) 
	{
		children.Add (node);
	}

	public bool isSuccessful()
	{

		return this.state.Equals (State.Success); 

	}

	public bool hasFailed () 
	{

		return this.state.Equals (State.Failure); 
	}

	public bool isRunning () 
	{
		
		return this.state.Equals (State.Running); 

	}
}
