//using UnityEngine;
//using System.Collections;
//
//// implments IHeapItem Interface 
//public class Node : IHeapItem<Node>
//{
//	// to check if node is walkable or not , the only states they can be in
//	public bool isWalkable;
//	// which point the node represents in the world 
//	public Vector3 worldPosition;
//	//to make the grid keep track of thier own positions 
//	public int gridX;
//	public int gridY;
//	// distance from the starting node 
//	public int gCost;
//	//distance from end node (Heuristics)
//	public int hCost;
//	public Node parent;
//	int heapIndex;
//
//	// constrcutor that takes the values above 
//	public Node(bool walkable, Vector3 worldPos, int _gridX, int _gridY)
//	{
//		isWalkable = walkable;
//		worldPosition = worldPos;
//		gridX = _gridX;
//		gridY = _gridY;
//	}
//
//	// calculataes and returns the fcost of the movemnt  which is gcost+fCost
//	// if the nodes have the same costs it will choose the node closest to the endPoint ; 
//	public int fCost
//	{
//		get
//		{
//			return gCost + hCost;
//		}
//	}
//
//
//	public int HeapIndex
//	{
//		get 
//		{
//			return heapIndex ; 
//		}
//		set 
//		{
//			heapIndex = value ; 
//		}
//	}
//	//comapretoMehtod to comapre two nodes f & h cost 
//	public int CompareTo(Node nodeToCompare )
//	{
//		int compare = fCost.CompareTo(nodeToCompare.fCost) ; 
//		if (compare == 0 )
//		{
//			compare = hCost.CompareTo(nodeToCompare.hCost);
//		}
//		// returns a negative comapre as the method returns 1 and we need -1 
//		return -compare ;	
//	}
//}