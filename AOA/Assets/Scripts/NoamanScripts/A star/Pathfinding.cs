//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using System ; 
//// the A* implemented here is based on the article in the website below and is a heavily upgraded implmetaiton of it 
////http://www.policyalmanac.org/games/aStarTutorial.htm
//// class does pathfinding for the Enemies for the game 
//
//public class Pathfinding : MonoBehaviour {
//	// refrence to requestmanager script 
//	PathRequestManager requestManager ;
//	//refrence to grid 
//	Grid grid;
//
//	void Awake()
//	{
//		grid = GetComponent<Grid> ();
//		requestManager = GetComponent <PathRequestManager>(); 
//	}
//
//
//	//to be called in order to start path & starts the coroutine 
//	public void StartFindPath (Vector3 startPos , Vector3 targetPos )
//	{
//		StartCoroutine (FindPath (startPos , targetPos));
//	}
//	// co routine to spread out the processing of find path over multiple frames to save performence 
//	IEnumerator FindPath(Vector3 startPos, Vector3 targetPos)
//	{
//		 Vector3 [] wayPoints = new Vector3[0];
//		bool pathSucess  = false; 
//		Debug.Log ("Starting FINDPATH"); 
//
//
//		// to set the start position & convert its cood from grid to world point 
//		Node startNode = grid.NodeFromWorldPoint(startPos);
//		Node targetNode = grid.NodeFromWorldPoint(targetPos);
//
//		//only does pathfinding if the startnode & are walkable 
//		if (startNode.isWalkable&& targetNode.isWalkable)
//		{
//        // heap is a custom class implmented in the heap script , its main purpose is for sorting 
//		//set of nodes to be evaluated 
//		Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
//		//set of nodes allready evaluated 
//		//hash set chosen  as it has the .Contains and .remove ability & has a complexity of o(N) which is faster 
//		//similar to a dictionary 
//		HashSet<Node> closedSet = new HashSet<Node>();
//		// adds start node to open list 
//		openSet.Add(startNode);
//
//			//checks if the openset has something in it 
//			while (openSet.Count > 0)
//			{
//				// temporary variable which adds the node in the open set with the lowest fcost 
//				Node currentNode = openSet.RemoveFirst();
//				closedSet.Add(currentNode);
//
//				if (currentNode == targetNode)
//				{
//					// if the path is found it will set pathSucees to true 
//					pathSucess = true ; 
//					//break put to exit the loop for pathfinding  
//					break; 
//				}
//
//
//				foreach (Node neighbour in grid.GetNeighbours(currentNode))
//				{
//					// checks if the node is in the clsoed list and if it is not walkbale 
//					if (!neighbour.isWalkable || closedSet.Contains(neighbour))
//					{
//						continue;
//					}
//
//					int newCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
//					if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
//					{
//						neighbour.gCost = newCostToNeighbour;
//						neighbour.hCost = GetDistance(neighbour, targetNode);
//						neighbour.parent = currentNode;
//						//checks if the open set does not have the neighbour and if teu it adds it 
//						if (!openSet.Contains(neighbour))
//						{
//							openSet.Add(neighbour);
//							Debug.Log ("Updateing openset with new neighbor "); 
//						}
//						else 
//						{
//							openSet.UpdateItem(neighbour);
//							Debug.Log ("Updateing openset"); 
//						}
//					}
//				}
//			}
//		}
//		yield return null;
//		if (pathSucess )
//		{
//			// to reverse the path 
//			wayPoints  = RetracePath(startNode,targetNode);
//		}
//		requestManager.FinsishedProcessingPath (wayPoints , pathSucess);
//
//	}
//
//	// the calculations are done from target to this objects position thus this mehtod is to reverse this 
//	Vector3 [] RetracePath(Node startNode, Node endNode)
//	{
//		List<Node> path = new List<Node>();
//		Node currentNode = endNode;
//		// retraces nodes from end to startNode to give a path
//		while (currentNode != startNode)
//		{
//			path.Add(currentNode);
//			currentNode = currentNode.parent;
//		}
//		Vector3[] waypoints =  SimplifyPath (path);
//		// all nodes are put in the array of vector3 above , this line of code will reverse them in the array named waypoints 
//		Array.Reverse (waypoints);
//		//returns array of vector3 
//		return waypoints ; 
//	}
//	// 
//	Vector3 [] SimplifyPath (List <Node> path)
//	{
//		List<Vector3 > waypoints = new List <Vector3>();
//		Vector2 directionOld = Vector2.zero ;
//
//		for (int i = 1 ; i < path.Count ; i++)
//		{
//			//gets the direction the enemy is moving by calculating the distance between two nodes 
//			Vector2 directionNew = new Vector2 (path[i-1].gridX - path[i].gridX , path[i-1].gridY - path[i].gridY);
//			//if path has changed diretion add waypoints to list 
//			if (directionNew != directionOld)
//			{
//				waypoints.Add (path [i].worldPosition);
//				directionNew = directionOld ; 
//			}
//		}
//		//converts list to an array 
//		return waypoints.ToArray ();
//	}
//
//	//to get the distance betweeen two nodes
//	int GetDistance(Node nodeA, Node nodeB)
//	{
//		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
//		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
//
//		//14y + 10 (X-y) -> this is onlt if x is greater than y 
//		//14x +10 (y-x) -> this is if y is greater than x 
// 		if (dstX >= dstY)
//		{
//			return 14*dstY + 10* (dstX-dstY);
//		}
//		return 14*dstX + 10 * (dstY-dstX);
//	}
//}
