using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerOperator : MonoBehaviour {

	public GameObject health ;
	public GameObject shield ;


	public int currentPlayerHealth;
	public int maxPlayerHealth;
	public int currentPlayerShield; 
	public int maxShield;

	public int playerDamage;
	public int playerDefense;
	public Vector3 playerSpeed;
	public Transform muzzlePosition;
	public Vector3 cursorPosition;
	public float playerSpdMdf;
	public float playerMaxSpeed;

	Rigidbody pRB;
	float healthPercentage ;
	float shieldPercentage ;

	Renderer rendShield ; 
	Renderer rendHealth ; 
	float gapBetweenPlayerAndMouse;
	float lookAhead;
	float h, v;

	bool turnOnSpawner = false;

	void Start ()
	{
		lookAhead = 2; 
		rendShield =  shield.GetComponent<Renderer>(); 
		rendHealth =  health.GetComponent<Renderer>();
		pRB = GetComponent<Rigidbody> ();
	}
		
	public int getPlayerDamage()
	{
		return playerDamage;
	}
	public void getAndTakeDamage(int dmg)
	{
		if (currentPlayerShield > 0) {
			currentPlayerShield -= dmg;
		} else {
			currentPlayerHealth -= dmg;
		}
	}

	public int getCurrentPlayerShield()
	{
		return currentPlayerShield;
	}

	public int getCurrentPlayerHealth()
	{
		return currentPlayerHealth;
	}

	void Attack()
	{
		if (Time.timeScale == 1) {
			GameObject.Find ("BulletSpawn").GetComponent<BulletPooling> ().AccessBullet (muzzlePosition.position);
			GameObject.Find ("GunShotSource").GetComponent<AudioSource> ().Play();
		}
	}

	void Die()
	{
		GameObject.Find ("GameManager").GetComponent<GameManager> ().PlayerDied ();
		Destroy (gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
		healthPercentage =  currentPlayerHealth/100; 
		shieldPercentage = currentPlayerShield/100;

		rendShield.material.color = Color.Lerp (Color.white ,Color.cyan , shieldPercentage );
		rendHealth.material.color = Color.Lerp (Color.green ,Color.red , healthPercentage );

		if (currentPlayerHealth <= 0)
		{
			currentPlayerHealth = 0;
			Die();
		}

		//gapBetweenPlayerAndMouse = (this.gameObject.transform.position.z - Camera.main.transform.position.z)*lookAhead;
		cursorPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
		cursorPosition = Camera.main.ScreenToWorldPoint (cursorPosition);
		cursorPosition.y = 0;
		transform.LookAt (cursorPosition, Vector3.up);

		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis("Vertical");


		playerSpeed = new Vector3 (h, 0, v);
//
//		transform.position += playerSpeed;

		//if (Input.GetKey (KeyCode.W))
		//{
			//playerSpeed = transform.forward * playerMaxSpeed * Time.deltaTime;
			//transform.position += playerSpeed;		
			//transform.position += transform.forward * Time.deltaTime*playerMaxSpeed;
		//}
			
		if (Input.GetMouseButtonDown(0)) 
		{
			Attack ();
		}

//		if (Input.GetKeyDown(KeyCode.Return)) 
//		{
//			GameObject.Find("GameManager").GetComponent<GameManager>().SetWaveState();
//		}
	}
	void FixedUpdate()
	{
		pRB.AddForce(playerSpeed * playerSpdMdf);
		pRB.velocity = Vector3.ClampMagnitude(pRB.velocity, playerMaxSpeed);
	}
}