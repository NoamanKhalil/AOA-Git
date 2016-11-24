using UnityEngine;
using System.Collections;

public class ObstacleStats : MonoBehaviour {

	public GameObject obstaclePrefab;
	int currentObstacleHealth;
	int totalObstacleHealth;

	public void TakeDamage(int dmg)
	{
		currentObstacleHealth -= dmg;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
