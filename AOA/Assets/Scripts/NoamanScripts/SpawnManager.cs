using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
	// array for primary spawn points 
	public GameObject [] spawnPoints ; 

	bool canRandomize ;
	int waveNum ;
	int enemyNum ; 
	int waveIndex ; 

	// Use this for initialization
	void Start ()
	{
		spawnPoints =  GameObject.FindGameObjectsWithTag("SpawnLocation");
		waveNum = GetComponent<GameManager>().currentWave ;
		canRandomize = true;
		InvokeRepeating ("makeSpawnHappen" , 2 ,1) ; 
		//get wave num from manager 
	}

	// Update is called once per frame
	void Update ()
	{
		
	}




	void makeSpawnHappen ()
	{
		//check to randimize or not 
		if (canRandomize==true)
		{
			// rondomiziation of spawn points 
			waveIndex = Random.Range (0, spawnPoints.Length);
		}
		// loop to instaite the number of enemies 
		for (int i =1 ; waveNum > 0 ; i++)
		{
			if (waveNum > 0)
			{
				canRandomize = false;
				Debug.Log ("waveNum is being called ");
			}
			else 
			{
				canRandomize = true ; 
				Debug.Log ("canRandomize is being called ");
			}
			spawnPoints[waveIndex].GetComponent<Spawn>().createEnemy ();
			Debug.Log("Update in spawn manager working ");
			// instanite one spawn point 
			//Spawn._instance.createEnemy ();
			waveNum -- ;
		}

		//call insatiate meth for all 3 and randomize 

	}

}