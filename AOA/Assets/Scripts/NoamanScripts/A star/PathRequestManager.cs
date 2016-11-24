//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic ;
//using System ;
////All the Enemies will request this class to find a path for them 
//
//public class PathRequestManager : MonoBehaviour
//{
//	// all the enemies will add the request the queue 
//	Queue <PathRequest> pathRequestQueue = new Queue<PathRequest>();
//	PathRequest currentPathRequest ; 
//
//	static PathRequestManager instance ; 
//	//instance of the pathfindisng class to fins the path 
//	Pathfinding pathfinding ;
//
//	bool isProcessingPath ; 
//
//	void Awake ()
//	{
//		instance = this ; 
//		pathfinding = GetComponent<Pathfinding> ();
//	}
// 
//	// action is used to encapsulate a method that has a single paramter and does not return a vlaue instead returns Yes / no ;
//	// since the requests are going to be processed it will be stored in the action 
//	public static void RequestPath (Vector3 pathStart , Vector3 pathEnd , Action <Vector3[],bool> callback  )
//	{
//		PathRequest newRequest = new PathRequest (pathStart , pathEnd , callback);
//		// adding stuff to the queue
//		instance.pathRequestQueue.Enqueue (newRequest);
//		instance.tryToProcessNext ();
//	}
//    
//	// it will go through the qeue and try to process the pathfinding request for the next item in the qeue 
//	// asks the pathfinding script to process the next path
//	void tryToProcessNext ()
//	{
//		// checks if the count is not empty 
//		if (!isProcessingPath&& pathRequestQueue.Count > 0 )	
//		{
//			// checks id the current path that is requested is in the eque and removes it ;
//			// gets the first item in the queue and removes it from the queue
//			currentPathRequest = pathRequestQueue.Dequeue ();
//			isProcessingPath = true ;
//
//			// to  start finding the path via the PathRequest Script & ending the path 
//			pathfinding.StartFindPath (currentPathRequest.pathStart , currentPathRequest.pathEnd);
//		}
//	}
//	//called by the pathfinding scirpt once it is done finding the path 
//	public void FinsishedProcessingPath (Vector3 [] path , bool success )
//	{
//		currentPathRequest.callback (path,success);
//		isProcessingPath = false;
//		tryToProcessNext();
//	}
//
//	public struct PathRequest 
//	{
//		public Vector3 pathStart ;
//		public Vector3 pathEnd ;
//		public  Action <Vector3[],bool> callback ; 
//		public PathRequest (Vector3 _start , Vector3 _end, Action<Vector3[],bool > _callback)
//		{
//			pathStart = _start ;
//			pathEnd= _end ; 
//			callback= _callback;
//		}
//
//	}
//}
