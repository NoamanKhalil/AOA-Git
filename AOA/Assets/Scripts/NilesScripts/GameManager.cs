using UnityEngine;
using System.Collections;
using UnityEngine.UI ; 
public class GameManager : MonoBehaviour {

	public Text healthText;
	public Text shieldText;
	public Text scoreText;
	public Text survivorsAliveText;
	public Text fuelLevelText;
	public Text creditsText;

	public int currentWaveNumber;
	public int currentWave;
	public int numOfWaves;
	public int currency;
	public GameObject playerPrefab;
	public Transform playerSpawn;
	public int playerScore;
	int scoreAwarded;
	public int activeEnemies;
	public int playerLives;
	public int waveDelay;
	int wavesRemaining;
	int respawnDelay;
	int scoreCount;

	int playerHealth;
	int playerShield;
	//GameObject player;

	float timeToWaveStart;
	float currentTime;

	bool gameIsRunning;
	//bool beginWave;
	bool isThereAPlayer;
	bool gameStart;
	bool waveActive;
	public bool playerAlive;

	// Use this for initialization
	void Start () 
	{
		gameIsRunning = false;
		//beginWave = false;
		isThereAPlayer = false;
		playerAlive = false;
		gameStart = false;
		waveActive = false;
		currentWaveNumber = 0;
		currentWave = 0;
		playerScore = 0;
		numOfWaves = 15;
		activeEnemies = 0;
		waveDelay = 0;
		playerLives = 3;


	}

//	public bool getGameState(bool gameStart)
//	{
//		//Call bool result from menu
//		return gameStart;
//	}

	public int GetCurrentWaveNumber()
	{
		return currentWaveNumber;
	}

	public int GetRemainingWaves()
	{
		return wavesRemaining;
	}

	public void SetEnemyCount(int enemies)
	{
		activeEnemies = enemies;
	}

	public void StartGame()
	{
		gameStart = !gameStart;
	}

	public void PlayerDied()
	{
		playerAlive = false;
	}

	void SpawnPlayer()
	{
		GameObject player = (GameObject)Instantiate (playerPrefab, playerSpawn.position, Quaternion.identity); 
	}

	void WaveManagement()
	{
		GetComponent<SpawnControllerVeta>().SetSpawnState();
		//retrieve wave size and increment enemy count
		//activeEnemies = GetComponent<SpawnControllerVeta> ().GetEnemyCount();
		waveActive = true;
	}

	public void HandleScoreandCurrency(int pointReward, int cashReward)
	{
		scoreAwarded = pointReward / scoreCount;
		if (scoreAwarded <= 0) {
			scoreAwarded = 20;
		}
		//increase score when enemy dies and decrease enemy count, track how much time passes since wave start and enemies die
		playerScore += scoreAwarded;
		currency += cashReward;
		activeEnemies--;
	}


	// Update is called once per frame
	void Update () 
	{
		wavesRemaining = (numOfWaves - currentWaveNumber);

		//playerHealth = GameObject.Find ("soldierPlayer(Clone)").GetComponent<PlayerOperator> ().getCurrentPlayerHealth ();
		//playerDefense = GameObject.Find ("soldierPlayer(Clone)").GetComponent<PlayerOperator> ().getCurrentPlayerDefense ();

		healthText.text = (""+playerHealth);
		shieldText.text = ("")+ playerShield;
		scoreText.text = ("")+playerScore;
		survivorsAliveText.text =("")+ playerLives;
		fuelLevelText.text = (wavesRemaining + " Waves to Survive until ship is fueled");
		creditsText.text =("")+ currency;

		if (Input.GetKeyDown(KeyCode.Return)) 
		{
			StartGame();
		}
		//Find Game State - Attach to Main Menu Code
		if (gameStart == true) 
		{
			gameIsRunning = true;
			gameStart = !gameStart;
		}

		//Check Game has Started
		if (gameIsRunning == true) 
		{
			//when waveNumber reaches total announce player's win and store their current score.
			if (currentWaveNumber <= numOfWaves) 
			{
				//Load Player
				if (isThereAPlayer == false) 
				{
					SpawnPlayer ();
					isThereAPlayer = true;
					playerAlive = true;
				}
				if (playerLives > 0) {
					if (playerAlive == false) {
						if (respawnDelay == 30) {
							SpawnPlayer ();
							playerLives--;
							playerAlive = true;
							respawnDelay = 0;
						}
						respawnDelay++;
					} 
				} else {
					//failState
				}

				playerHealth = GameObject.Find ("soldierPlayer(Clone)").GetComponent<PlayerOperator> ().getCurrentPlayerHealth ();
				playerShield = GameObject.Find ("soldierPlayer(Clone)").GetComponent<PlayerOperator> ().getCurrentPlayerShield ();
				//Begin Wave Management
				//when enemies = 0 declare wave is over wait to a count of 15 then increment wave number and begin wave phase over again.
				if (activeEnemies <= 0) 
				{
					waveDelay++;
					if (waveDelay == 100) 
					{
						if (waveActive == true) {
							currentWaveNumber++;
							scoreCount = 0;
							waveActive = !waveActive;
						}

						activeEnemies = 0;
						//Communicate to Spawner wave number and to spawn enemies
						WaveManagement ();
						waveDelay = 0;
					}
				}
				scoreCount++;
			} 
			else 
			{
				//WinState
				//Stick Score in Front of the Player
				//Plus return to menu button 
			}
		}
	}
}
