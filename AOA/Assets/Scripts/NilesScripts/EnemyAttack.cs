using UnityEngine;
using System.Collections;
using System;

public class EnemyAttack : MonoBehaviour {

	public GameObject [] allTurrets;
	Transform Player;
	Transform centralShip;
	public GameObject closestTurret; 
	public float closestTurretDistance;
	public float turretDistance;
	public float playerDistance;
	public float shipDistance;
	public Vector3 targetedTurretPosition;
	Vector3 playerDirection;
	Vector3 shipDirection;
	Vector3 turretDirection;
	Quaternion faceTowards;
	Vector3 enemyRotation;

	public bool hasPath;

	// Use this for initialization
	void Start () {
		closestTurretDistance = Mathf.Infinity;
		allTurrets = GameObject.FindGameObjectsWithTag ("Turret");
		centralShip = GameObject.Find ("SpaceShuttle").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Logic Write out Time
		//So Find Turret Code Should find the turrets and compare the distances
		//Also include player position and have it supercede any turret or ship targeting
		//Next need to make it so the enemy moves toward that target to "attack" them
		//additionally make an if nest for targeting
		//Player>Turrets>ship and logic changes at 75(maybe not), 50 and 25% health.
		Player = GameObject.Find ("soldierPlayer(Clone)").GetComponent<Transform> ();

		playerDistance = Vector3.Distance (this.transform.position, Player.position);
		shipDistance = Vector3.Distance (this.transform.position, centralShip.position); 

		foreach (GameObject turret in allTurrets) 
		{
			//draws distance from all turrets and all enemies
			turretDistance = Vector3.Distance (this.transform.position, turret.transform.position); 

			if (turretDistance < closestTurretDistance) 
			{
				closestTurretDistance = turretDistance;
				targetedTurretPosition = turret.transform.position;
			}
		}

		if(playerDistance < closestTurretDistance || 
			(float)(GetComponent<enemyController> ().currentEnemyHealth/ GetComponent<enemyController> ().totalEnemyHealth) * 100 <= 50 
			&& (float)(GetComponent<enemyController> ().currentEnemyHealth/ GetComponent<enemyController> ().totalEnemyHealth) * 100 >= 25)
		{
			//this.transform.Translate (Player.position);
			playerDirection = Player.position - this.transform.position;
			faceTowards = Quaternion.LookRotation (playerDirection);
			enemyRotation = faceTowards.eulerAngles;
			this.transform.rotation = Quaternion.Euler (0, enemyRotation.y, 0);

			this.transform.position = Vector3.MoveTowards(this.transform.position, Player.position, 0.1f);
		}
		else if ((float)(GetComponent<enemyController> ().currentEnemyHealth/ GetComponent<enemyController> ().totalEnemyHealth) * 100 <= 24)
		{
			//this.transform.Translate (centralShip.position);
			shipDirection = centralShip.position - this.transform.position;
			faceTowards = Quaternion.LookRotation (shipDirection);
			enemyRotation = faceTowards.eulerAngles;
			this.transform.rotation = Quaternion.Euler (0, enemyRotation.y, 0);

			this.transform.position = Vector3.MoveTowards(this.transform.position, centralShip.position, 0.1f);
		}
		else
		{
			//this.transform.Translate (targetedTurretPosition);
			turretDirection = targetedTurretPosition - this.transform.position;
			faceTowards = Quaternion.LookRotation (turretDirection);
			enemyRotation = faceTowards.eulerAngles;
			this.transform.rotation = Quaternion.Euler (0, enemyRotation.y, 0);

			this.transform.position = Vector3.MoveTowards(this.transform.position, targetedTurretPosition, 0.1f);
		}
				
	} 
}
