using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour {

	Vector3 target;
	Vector3 currentPosition;
	float baseSpeed;
	float speedMDF;
	int pathSize;
	int positionNum;
	Vector3 direction;


	// Use this for initialization
	void Start () {
		float baseSpeed = 5.0f;
	}
	//int pathEntry
	void AssignTarget()
	{
		//Feed in path data, assign entry as target
		target = GameObject.FindGameObjectWithTag("Turret").GetComponent<Transform>().position;
	}
	
	// Update is called once per frame
	void Update () {
		//Find Path size and assign to pathSize value
		speedMDF = baseSpeed * Time.deltaTime;
		currentPosition = GetComponent<Transform> ().position;

		//positionNum = 1st path value;
		AssignTarget ();

		//direction = target - currentPosition;

		GetComponent<Transform> ().position = Vector3.MoveTowards (currentPosition, target, speedMDF);



	}
}
