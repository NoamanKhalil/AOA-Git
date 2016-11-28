using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Transform targetPosition;
	public Vector3 bulletTvlDist;
	Vector3 bltSpeed;
	public Vector3 bltVelo;
	public Vector3 firingPosition;
	public Vector3 targetLine;
	public int bulletDamage;
	public int bulletID;
	float bulletStartTime;
	public int liveBulletCount;

	public bool activeBullet;

	// Use this for initialization
	void Start () {
		activeBullet = false;
		//bulletDamage = GameObject.Find("Soldier").GetComponent<PlayerOperator> ().getPlayerDamage();
		int liveBulletCount;
	}

	// Update is called once per frame
	Vector3 CalculateDistanceandSpeed(Vector3 target, Vector3 start)
	{
		bulletTvlDist = (target - start);
		bltSpeed = bulletTvlDist * Time.deltaTime;
		return bltSpeed;

	}

	void OnCollisionEnter(Collision enemy)
	{
		if (enemy.gameObject.tag == "Enemy") 
		{
			this.gameObject.GetComponent<Rigidbody> ().Sleep ();
			enemy.gameObject.GetComponent<enemyController>().getAndTakeDamage(bulletDamage);
			activeBullet = false;
			this.gameObject.GetComponent<Transform> ().position = GameObject.Find ("BulletSpawn").GetComponent<Transform> ().position;
			liveBulletCount = 0;
			enemy.gameObject.GetComponentInChildren<Material>().color = Color.red ;
			Debug.Log ("called");
		}


	}

	// Update is called once per frame
	void Update () 
	{
		firingPosition = GameObject.Find ("Muzzle").GetComponent<Transform> ().position;
		firingPosition = new Vector3((int)firingPosition.x, 0, (int)firingPosition.z);
		targetLine = GameObject.Find ("GunTarget").GetComponent<Transform> ().position;
		targetLine = new Vector3((int)targetLine.x, 0, (int)targetLine.z);
		if (activeBullet == true) 
		{
			bulletStartTime = Time.time;
			bltVelo = CalculateDistanceandSpeed (targetLine, firingPosition);

			this.gameObject.GetComponent<Rigidbody> ().AddForce((bltVelo * 100), ForceMode.Impulse);

			//bltVelo += bulletTvlDist * Time.deltaTime;
			liveBulletCount++;
			if(liveBulletCount == 100)
			{
				this.gameObject.GetComponent<Rigidbody> ().Sleep ();
				activeBullet = false;
				this.gameObject.GetComponent<Transform> ().position = GameObject.Find ("BulletSpawn").GetComponent<BulletPooling> ().ReturnBullet();
				liveBulletCount = 0;
			}
		}

	}
}
