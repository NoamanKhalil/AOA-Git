/*using UnityEngine;
using System.Collections;
// intermediatery class to be used by behaviour tree to call the A*

public class Unit : MonoBehaviour {

	public Transform target ;
    float speed = 5 ;
	Vector3 []path ;
	int targetIndex ;

	void Start ()
	{
		//call this in the enemy behaviour class under the pathfind behaviour 
		//PathRequestManager.RequestPath (transform.position , target.position , OnPathFound );
	}

	// to be called to start the pathfinding 
	public void requestPath (Transform Target)
	{
		PathRequestManager.RequestPath (transform.position , Target.position , OnPathFound );
	}
	// when the path of found it will start movemnt of the enemy 
	public  OnPathFound (Vector3[] newPath , bool pathSuccessful)
	{
		if (pathSuccessful)
		{
			path = newPath ;
			//return path;
			//targetIndex = 0 ;
			//StopCoroutine ("FollowPath");
			//StartCoroutine ("FollowPath");
			
		}
	}

	//coroutine to spread the movemnet calculations over multiple frames &&  move the enemy 
	IEnumerator FollowPath()
	{
		Vector3 currentWaypoint = path[0];
		while (true)
		{
			if (transform.position == currentWaypoint)
			{
				targetIndex ++;
				if (targetIndex >= path.Length)
				{
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
			yield return null;

		}
	}

	// the gizmo will create a cubes for each point and a line to the
	public void OnDrawGizmos ()
	{
		if (path!= null)
		{
			for (int i = targetIndex ; i < path.Length ; i++ )
			{
				Gizmos.color = Color.black ; 
				Gizmos.DrawCube (path[i], Vector3.one);
				if (i == targetIndex)
				{
					Gizmos.DrawLine (transform.position , path [i]);
				}
				else
				{
					Gizmos.DrawLine (path[i-1] , path [i]);
				}
			}
		}
	}
}*/