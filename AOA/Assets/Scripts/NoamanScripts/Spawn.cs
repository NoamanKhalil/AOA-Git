using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	// to check which bool is enabled for each spawn point , to be used to 
	public bool spawn0 , spawn1,spawn2 ; 
	// array for sub spawn points 
	public GameObject []points;
	//prefab for enemy prefab 
	public GameObject enemyObject ; 


	void Awake()
	{
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{


	}

	// method to randomize and insatniate enemies at random spawn points 
	public void createEnemy ()
	{
		int t = Random.Range(0, points.Length-1);
		if (spawn0 == true)
		{
			Debug.Log ("Create enemy wokring ");
			Instantiate(enemyObject, points[t].transform.position, Quaternion.identity);
		}
		else if (spawn1 == true)
		{
			Instantiate(enemyObject, points[t].transform.position, Quaternion.identity);
		}
		else if (spawn2 == true)
		{
			Instantiate(enemyObject, points[t].transform.position, Quaternion.identity);
		}

	}
}