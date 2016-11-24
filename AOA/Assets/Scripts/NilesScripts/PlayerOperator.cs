using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerOperator : MonoBehaviour {

	public Text healthText;
	public Text shieldText;

	public int currentPlayerHealth;
	public int maxPlayerHealth;
	public int currentPlayerShield; 
	public int maxShield;

	public int playerDamage;
	public int playerDefense;
	public Vector3 playerSpeed;
	public Transform muzzlePosition;
	public Vector3 cursorPosition;
	public float playerMaxSpeed = 30.0f;

	float gapBetweenPlayerAndMouse;
	float lookAhead;
	float h, v;

	bool turnOnSpawner = false;

	void Start ()
	{
		lookAhead = 2; 
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
		//healthText.text = ("Health: " + currentPlayerHealth);
		//shieldText.text = ("Shield: ") + playerDefense;

		if (currentPlayerHealth <= 0)
		{
			Die();
		}

		//gapBetweenPlayerAndMouse = (this.gameObject.transform.position.z - Camera.main.transform.position.z)*lookAhead;
		cursorPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
		cursorPosition = Camera.main.ScreenToWorldPoint (cursorPosition);
		cursorPosition.y = 0;
		transform.LookAt (cursorPosition, Vector3.up);

		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis("Vertical");

		playerSpeed = new Vector3 (h, 0, v) * playerMaxSpeed * Time.deltaTime;

		transform.position += playerSpeed;

		if (Input.GetMouseButtonDown(0)) 
		{
			Attack ();
		}

//		if (Input.GetKeyDown(KeyCode.Return)) 
//		{
//			GameObject.Find("GameManager").GetComponent<GameManager>().SetWaveState();
//		}
	}
}