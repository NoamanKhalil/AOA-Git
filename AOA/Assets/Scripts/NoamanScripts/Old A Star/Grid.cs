using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public bool onlyDisplayPathGizmos;
	// to specify which layer is unWalkable 
	public LayerMask unwalkableMask;
	// going to define area in world cood that the grid will cover 
	public Vector2 gridWorldSize;
	// size of each node 
	public float nodeRadius;
	Node[,] grid;

	float nodeDiameter;
	int gridSizeX, gridSizeY;

	void Start()
	{
		nodeDiameter = nodeRadius*2;
		// gives the number of nodes you can fit into the grid 
		// converts to int in order to return int values else it would create a fraction of a node 
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
		CreateGrid();
	}

	// used ot get the maximum grid size 
	public int MaxSize
	{
		get
		{
			return gridSizeX * gridSizeY;
		}
	}
	//  method to cretae the grid 
	void CreateGrid()
	{
		//2d array of nodes 
		grid = new Node[gridSizeX,gridSizeY];
		// gets the bottom left  vector3 pos for the grid 
		// z pos will be y as the grid is top down 
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;
		// loops theough all positions in the grid 
		// does a collison check to check if the node is walkable or not 
		// starts from the bottom left of the grid 
		for (int x = 0; x < gridSizeX; x ++)
		{
			for (int y = 0; y < gridSizeY; y ++)
			{
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				// collision check 
				// returns true if there is no collision and returns false if there is a collision
				// check sphere returns true/ false 
				bool walkable = !(Physics.CheckSphere(worldPoint,nodeRadius,unwalkableMask));
				grid[x,y] = new Node(walkable,worldPoint, x,y);
			}
		}
	}
	// checks in a 3*3 grid for the neighbours 
	public List<Node> GetNeighbours(Node node)
	{
		List<Node> neighbours = new List<Node>();

		for (int x = -1; x <= 1; x++)
		{
			for (int y = -1; y <= 1; y++) 
			{
				if (x == 0 && y == 0)
					//checks if the costs are both 0 and skips the check and runs the for loops again 
					continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;
				// chekcs if the node is the neighbour or not 
				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
				{
					neighbours.Add(grid[checkX,checkY]);
				}
			}
		}

		return neighbours;
	}

	// to be used to convert the start and end node positons 
	public Node NodeFromWorldPoint(Vector3 worldPosition)
	{
		// converts world postion to a percentage  (Both x and y ) and checks how far it is in the grid 
		//if it is far left it will be a percentage of  0  , middle 0.5 and right a percentage of 1 
		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
		float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
		// used to clamp between 0 and 1 
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		// rounded to a int so it does not give errors in the array of grid 
		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
		return grid[x,y];
	}


	// gizmos used to visualize grid & path 
	public List<Node> path;
	void OnDrawGizmos() 
	{
		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x,1,gridWorldSize.y));

		if (onlyDisplayPathGizmos)
		{
			if (path != null) {
				foreach (Node n in path)
				{
					Gizmos.color = Color.black;
					Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
				}
			}
		}
		else
		{

			if (grid != null)
			{
				foreach (Node n in grid)
				{
					// checks if it is walkable it will be white 
					// else it will be red if it is unwalkable 
					Gizmos.color = (n.isWalkable)?Color.white:Color.red;
					if (path != null)
					if (path.Contains(n))
						Gizmos.color = Color.green;
					Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter-.1f));
				}
			}
		}
	}
}