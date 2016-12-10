using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System ; 

/**
 *The A* implemented here is based on the article in the website below and is a heavily upgraded implmetaiton of it 
 * 
 * http://www.policyalmanac.org/games/aStarTutorial.htm
 * 
 * class does pathfinding for the Enemies for the game 
**/

public class PathFinding : MonoBehaviour
{

	public Transform seeker, target;
	private Vector3[] tempArray ;
	//public bool pathFound = false ;
	Grid grid;

	public static PathFinding instance;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this ; 
		} 
		else 
		{
			Destroy (this); 
		}
	}
	//Method to be called for pathfidning , return a array of vector3s 
	public Vector3 [] showMeTheWay (Transform StartPos , Transform TargetPos)
	{
		// TODO :  cehck if array is null and return 


		grid = GameObject.Find ("GRID").GetComponent<Grid>(); 
		seeker = StartPos ;
		target= TargetPos ;
		FindPath(seeker.position,target.position);

		//pathFound = true ; 
		return tempArray ; 
	}

	void FindPath(Vector3 startPos, Vector3 targetPos)
	{

		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
		HashSet<Node> closedSet = new HashSet<Node>();
		openSet.Add(startNode);

		// checks if the openset has somehtign in it 
		while (openSet.Count > 0)
		{
			Node currentNode = openSet.RemoveFirst();
			closedSet.Add(currentNode);
			// checks if the current node is the node it is trying to get to 
			if (currentNode == targetNode)
			{
				RetracePath(startNode,targetNode);
				return;
			}

			foreach (Node neighbour in grid.GetNeighbours(currentNode))
			{
				// checks if the neighbour is not  walkable and is in the closed set 
				if (!neighbour.isWalkable || closedSet.Contains(neighbour))
				{
					continue;
				}

				int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
				if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newMovementCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = currentNode;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
					else 
					{
						openSet.UpdateItem(neighbour);
					}
				}
			}
		}
	}
		
		// the calculations are done from target to this objects position thus this mehtod is to reverse this 
		Vector3 [] RetracePath(Node startNode, Node endNode)
		{
			List<Node> path = new List<Node>();
			Node currentNode = endNode;
			// retraces nodes from end to startNode to give a path
			while (currentNode != startNode)
			{
				path.Add(currentNode);
				currentNode = currentNode.parent;
			}
		    Vector3[] waypoints = SimplifyPath (path);
		   
			// all nodes are put in the array of vector3 above , this line of code will reverse them in the array named waypoints 
			Array.Reverse (waypoints);
		    tempArray = waypoints;
			//returns array of vector3 
			return waypoints ; 
		}
		// converts actual nodes to world postions
		Vector3 [] SimplifyPath (List <Node> path)
		{
			List<Vector3 > waypoints = new List <Vector3>();
			Vector2 directionOld = Vector2.zero ;
	
			for (int i = 1 ; i < path.Count ; i++)
			{
				//gets the direction the enemy is moving by calculating the distance between two nodes 
				Vector2 directionNew = new Vector2 (path[i-1].gridX - path[i].gridX , path[i-1].gridY - path[i].gridY);
				//if path has changed diretion add waypoints to list 
				if (directionNew != directionOld)
				{
					waypoints.Add (path [i].worldPosition);
					directionNew = directionOld ; 
				}
			}
			//converts list to an array 
			return waypoints.ToArray ();
		}

	//calculates distnaces between two nodes
	int GetDistance(Node nodeA, Node nodeB) {
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);


		// to calculate the movemnt cost IE up down left right is 10 and diagonal is 14
		if (dstX > dstY)
			return 14*dstY + 10* (dstX-dstY);
		return 14*dstX + 10 * (dstY-dstX);
	}


}