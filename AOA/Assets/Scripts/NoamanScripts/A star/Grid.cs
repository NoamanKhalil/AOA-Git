//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//// Note : the x is x y is z and z is y as this is a grid system being seen from a top down view
//
//public class Grid : MonoBehaviour
//{
//	public bool displayGridGixzmos;
//	// to check for the layer mask that it cannot walk on 
//	public LayerMask unwalkableMask;
//
//	//defines the area in world coordiantes in which the grid will cover 
//	public Vector2 gridWorldSize;
//	// to define how much of a size does each node cover 
//	public float nodeRadius;
//	//2d array that the nodes will be in 
//	Node[,] grid;
//	// size of each individual node 
//	float nodeDiameter;
//	int gridSizeX, gridSizeY;
//
//	void Awake()
//	{
//		//to check how many nodes we can make in the wire frame  inthe x & y 
//		nodeDiameter = nodeRadius*2;
//		//using mroundtoint to make sure there is not half node 
//		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
//		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
//		CreateGrid();
//	}
//	//Used to set maximum size of array in heap class 
//	public int MaxSize
//	{
//		get
//		{
//		return gridSizeX * gridSizeY ; 
//		}
//	}
//	//creates an invisible grid for the pathfinding to work
//	void CreateGrid()
//	{
//		// size of the grid 
//		grid = new Node[gridSizeX,gridSizeY];
//		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;
//
//		//loops throguh each grid to do a collision check to check if the node is walkable or not 
//		for (int x = 0; x < gridSizeX; x ++)
//		{
//			for (int y = 0; y < gridSizeY; y ++)
//			{
//				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
//				// going to be true if nothing collides with the gizmo
//				// checksphere returns a true/false
//				bool walkable = !(Physics.CheckSphere(worldPoint,nodeRadius,unwalkableMask));
//				// x and y put at the end so that eahc node can keep track of thier own x and y cood when they are made 
//				grid[x,y] = new Node(walkable,worldPoint, x,y);
//			}
//		}
//	}
//	public List<Node> GetNeighbours(Node node)
//	{
//		List<Node> neighbours = new List<Node>();
//
//		for (int x = -1; x <= 1; x++)
//		{
//			for (int y = -1; y <= 1; y++)
//			{
//				//if they are in the centre of the block  to make sure its not the previous node node 
//				if (x == 0 && y == 0)
//				{
//					continue;
//				}
//
//				int checkX = node.gridX + x;
//				int checkY = node.gridY + y;
//
//				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
//				{
//					neighbours.Add(grid[checkX,checkY]);
//				}
//			}
//		}
//
//		return neighbours;
//	}
//	
//	// method to convert each nodes pos (each square gizmo) to world coordinates
//	public Node NodeFromWorldPoint(Vector3 worldPosition)
//	{
//		//converts to a percentage first if x is on the left it will be a percentage of 0
//		//x on the middle will be .5 and right will be 1 
//		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
//		float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
//		// to clamp between 0 and 1 
//		// if the node requestedis outside the array it throws null expection errors thus it is clamped 
//		percentX = Mathf.Clamp01(percentX);
//		percentY = Mathf.Clamp01(percentY);
//
//		// gets x and y indices , -1 is put becuase arrays count from 0 and not 1 
//		// rounded to get a int value 
//		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
//		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
//
//		return grid[x,y];
//	}
//		
//	void OnDrawGizmos()
//	{
//		// wire cube will show the area where the cubes will be crrated 
//		// z axis is represented by y as it will be top a top down grid 
//		//takes in a vector3 and uses 1 for the y becuase grid world size is a vector 2 
//		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y));
//
//		if (grid!=null && displayGridGixzmos)
//			{
//				foreach(Node n in grid)
//				{
//				    //acts like a bool to check if the grid is walkable and changes color based on it 
//				    // question mark is then and : is like saying else 
//					Gizmos.color = (n.isWalkable)?Color.white:Color.red;
//					//Gizmos.color = Color.cyan;
//					Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
//				}
//			}
//		
//	}
//}