using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class enemyController : MonoBehaviour
{
	public GameObject healthBar;
	Vector3 enemy;

	public float currentEnemyHealth;
	public float totalEnemyHealth;
	public float calcHealth;
	public float healthPercentage;
	public ParticleSystem particleSys ; 

	public int enemyDamage;
	public int enemyDefense;
	public Vector3 enemySpeed;

	Vector3 target;
	Vector3 currentPosition;
	// float baseSpeed;
	//float speedMDF;

	int enemyValue;
	int enemyReward;

	Renderer rend ; 
	float maxEnemySpeed;

	void Awake() 
	{
		particleSys = GetComponentInChildren<ParticleSystem>();
	}
	public int getEnemyDamage()
	{
		return enemyDamage;
	}
	public void getAndTakeDamage(int dmg)
	{
		currentEnemyHealth -= dmg;
		particleSys.Play();
		//Instantiate (particleSys , transform.position ,Quaternion.identity );
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
			target.gameObject.GetComponent<TowerBehaviour>().getAndTakeDamage(enemyDamage);
		}
	}

	// Use this for initialization
	void Start () {
		enemyValue = 1000;
		enemyReward = 100;
		rend =  healthBar.GetComponent<Renderer>(); 
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
	void Update () 
	{
		healthPercentage =  currentEnemyHealth/100; 
		rend.material.color = Color.Lerp (Color.red ,Color.green , healthPercentage );
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
