using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class enemyController : MonoBehaviour
{
	public GameObject healthBar;
	Vector3 enemy;

	public int currentEnemyHealth;
	public int totalEnemyHealth;
	public int calcHealth;

	public int enemyDamage;
	public int enemyDefense;
	public Vector3 enemySpeed;

	Vector3 target;
	Vector3 currentPosition;
	// float baseSpeed;
	//float speedMDF;

	int enemyValue;
	int enemyReward;

	float maxEnemySpeed;

	public int getEnemyDamage()
	{
		return enemyDamage;
	}
	public void getAndTakeDamage(int dmg)
	{
		currentEnemyHealth -= dmg;
		if (currentEnemyHealth <= 0) 
		{
			Die ();
		}
	}

	void OnCollisionEnter(Collision target)
	{
		if (target.gameObject.tag == "Player") 
		{
			target.gameObject.GetComponent<PlayerOperator>().getAndTakeDamage(enemyDamage);
		}
		else if (target.gameObject.tag == "Turret") 
		{
			//target.gameObject.GetComponent<tower>().TakeEnemyDamage(enemyDamage);
		}
	}

	// Use this for initialization
	void Start () {
		enemyValue = 1000;
		enemyReward = 100;
		//currentEnemyHealth = totalEnemyHealth;
		//enemy = GameObject.Find ("Turret").GetComponent<Transform> ().position;
	}

//	public void SetHealthBar (float enemyHealth)
//	{
//		healthBar.transform.localScale = new Vector3 (enemyHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
//	}

	void Die()
	{
		GameObject.Find ("GameManager").GetComponent<GameManager> ().HandleScoreandCurrency  (enemyValue, enemyReward);
		Destroy (gameObject);
	}

	
	// Update is called once per frame
	void Update () {

		//healthBar.fillAmount = (float)currentEnemyHealth / totalEnemyHealth;
		//calcHealth = currentEnemyHealth / totalEnemyHealth;
		//SetHealthBar (calcHealth);

//		speedMDF = baseSpeed * Time.deltaTime;
//		currentPosition = GetComponent<Transform> ().position;
//		target = GameObject.FindGameObjectWithTag("Turret").GetComponent<Transform>().position;
//
//		GetComponent<Transform> ().position = Vector3.MoveTowards (currentPosition, target, speedMDF);

	
	}
}
