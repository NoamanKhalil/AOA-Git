using UnityEngine;
using System.Collections;
using UnityEngine.UI ; 
public class PlayerControl : MonoBehaviour
{
	public Text shieldText;
	public Text healthText;
	public Text numofSurvivorsText ;
	public Text ammoText;

	public Camera cam;
	public GameObject projectile ;
	public int Survivors = 3 ;
	public float maxHealth = 150f ;
	public float  curHealth = 1f ;
	public float  shieldCapacity =1f ;
	public int bulletCount = 15 ; 
	public float playerSpeed = 2.0f ; 
	public float fireRate = 0.5F;
	public Transform bulletStartPos ;

	// used for determinging aniamtion in animationChanger
	private float nextFire = 0.0F;

	//rapid fire is a special ability in which player can fire slightly faster
	private int rapidfireCount ; 
	private Vector3 mousePos;

	// Use this for initialization
	void Start ()
	{
		curHealth = maxHealth ; 
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0))
		{
			//RotateToMouse ();
		}

		input () ; 
		if (curHealth <= 1)
		{
			//Application.LoadLevel ("Scene4"); 
		}
		shieldText.text =("Shield:")+shieldCapacity ;
		healthText.text = ("Health:")+curHealth ;
		numofSurvivorsText.text =("Survivors:")+Survivors ;
		ammoText.text =("Ammo:")+bulletCount+("∞") ; 
		// to limit the use of the rapid fire anility to only 40 projectiles
	}
	//all player input in this method
	void input ()
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Vector3 displacement = new Vector3 (h,0,v) *playerSpeed*Time.deltaTime ; 
		transform.position += displacement ;
		if (Time.deltaTime !=0  )
		{
			if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
			{
				nextFire = Time.time + fireRate;
				onAttack() ; 
			}
			// for the rapid fire ability
		}
	}
	void RotateToMouse() {
		Vector3 look = Input.mousePosition;
		look.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
		look = Camera.main.ScreenToWorldPoint(look);
		transform.LookAt(look);
	}
	void onAttack ()
	{
		if (bulletCount ==15)
		{
		// to normalize the vector and fire at the mouses position on the x and y .
		Vector3 direction = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -11 ); // change -11 
		direction = Camera.main.ScreenToWorldPoint (direction); 
		direction.Set(direction.x,direction.y,transform.position.z);

		GameObject bPrefab = (GameObject )Instantiate (projectile,bulletStartPos.position, Quaternion.identity);
		bPrefab.transform.LookAt (direction);
		direction = (direction - transform.position).normalized;
		direction.Set(direction.x,direction.y,0);                                      
		bPrefab.GetComponent<Rigidbody>().AddForce (direction * 500f);
		bulletCount-- ;
		}
		else 
		{
			if (Input.GetKey (KeyCode.R)&& bulletCount>15)
			{
				
				bulletCount ++  ; 
			}

		}
	}
	// called when player collides with enemy in the enemy behabiour. 
	public  void decreaseHealth ()
	{
		if (curHealth >=1 )
		{
			curHealth -= 5.0f ;
		}
		else
		{
			shieldCapacity -= 5.0f ; 
		}
	}
	void OnTriggerEnter(Collider other)
	{
		
	}

}