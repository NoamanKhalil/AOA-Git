using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Transform targetPosition;
	public Vector3 bulletTvlDist;
	public Renderer bulletRend;
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
		bulletRend = GetComponent<Renderer> ();
		bulletRend.enabled = false;
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
			bulletRend.enabled = false;
			this.gameObject.GetComponent<Rigidbody> ().Sleep ();
			enemy.gameObject.GetComponent<enemyController>().getAndTakeDamage(bulletDamage);
			activeBullet = false;
			this.gameObject.GetComponent<Transform> ().position = GameObject.Find ("BulletSpawn").GetComponent<Transform> ().position;
			liveBulletCount = 0;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		firingPosition = GameObject.Find ("Muzzle").GetComponent<Transform> ().position;
		firingPosition = new Vector3((int)firingPosition.x, 0, (int)firingPosition.z);
		targetLine = GameObject.Find ("GunTarget").GetComponent<Transform> ().position;
		targetLine = new Vector3((int)targetLine.x, 0, (int)targetLine.z);
//		if (activeBullet == true) 
//		{
//			bltVelo = CalculateDistanceandSpeed (targetLine, firingPosition);
//
//			this.gameObject.GetComponent<Rigidbody> ().AddForce((bltVelo * 100), ForceMode.Impulse);
//			liveBulletCount++;
//
//			if(liveBulletCount == 100)
//			{
//				this.gameObject.GetComponent<Rigidbody> ().Sleep ();
//				activeBullet = false;
//				this.gameObject.GetComponent<Transform> ().position = GameObject.Find ("BulletSpawn").GetComponent<BulletPooling> ().ReturnBullet();
//				liveBulletCount = 0;
//			}
//		}

	}

	void FixedUpdate()
	{
		if (activeBullet == true) 
		{
			bulletRend.enabled = true;
			bltVelo = CalculateDistanceandSpeed (targetLine, firingPosition);

			this.gameObject.GetComponent<Rigidbody> ().AddForce((bltVelo * 500), ForceMode.Impulse);
			liveBulletCount++;

			if(liveBulletCount == 100)
			{
				bulletRend.enabled = false;
				this.gameObject.GetComponent<Rigidbody> ().Sleep ();
				activeBullet = false;
				this.gameObject.GetComponent<Transform> ().position = GameObject.Find ("BulletSpawn").GetComponent<BulletPooling> ().ReturnBullet();
				liveBulletCount = 0;

			}
		}
	}
}
