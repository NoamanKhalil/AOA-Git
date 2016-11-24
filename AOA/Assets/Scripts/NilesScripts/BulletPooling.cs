using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPooling : MonoBehaviour {

	public GameObject bulletPrefab;
	GameObject Bullet;
	GameObject[] Bullets = new GameObject[15];
	Vector3 bulletPool;
	Quaternion bulletRotation;
	int selectedBullet;

	// Use this for initialization
	void Start () 
	{	
		bulletPool = GameObject.Find("BulletSpawn").GetComponent<Transform> ().position;
		//bulletRotation = GameObject.Find ("BulletSpawn").GetComponent<Transform> ().rotation;

		for (int i = 0; i < Bullets.Length; i++) 
		{
			GameObject Bullet = (GameObject)Instantiate(bulletPrefab, bulletPool, bulletRotation);
			Bullets [i] = Bullet;
			//Bullets [i].GetComponent<Bullet> ().bulletID;
		}

		selectedBullet = 0;
	}

	public void AccessBullet(Vector3 muzzleLoc)
	{
		if (selectedBullet == Bullets.Length) 
		{
			selectedBullet = 0;
		}
		Bullets [selectedBullet].GetComponent<Transform> ().position = muzzleLoc;
		Bullets [selectedBullet].GetComponent<Bullet> ().activeBullet = true;
		selectedBullet++;
	}

	public Vector3 ReturnBullet()
	{
		return bulletPool;
	}
		
	// Update is called once per frame
	void Update () 
	{

	}
}
