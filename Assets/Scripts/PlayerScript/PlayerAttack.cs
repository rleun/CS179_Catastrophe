using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public float timeBetweenAttacks = 1f;
	public int attackDamage = 1;
	Animator anim;
	GameObject enemy;
	GameObject player;
	PlayerHealth playerHealth;
	VacuumHealth vacHealth;

	EnemyHealth enemyHealthScript;
	bool hitEnemy;
	float timer;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		//Change later to encompase all enemies
		vacHealth = enemy.GetComponent <VacuumHealth> ();

	}

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerStay(Collider other)
	{
		//If Paw collides & during paw_swipe animation
		//Debug.Log (other.gameObject);
		if(((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "SecurityCamera") || (other.gameObject.tag == "Helicopter") || (other.gameObject.tag == "Robot")) && (anim.GetCurrentAnimatorStateInfo(0).IsName("paw_swipe")))
		{
			//Debug.Log(other.gameObject);

			hitEnemy = true;
			enemy = other.gameObject;
		}

		else if(!(anim.GetCurrentAnimatorStateInfo(0).IsName("paw_swipe")))
		{
			hitEnemy = false;
		}

	}
	
	void OnTriggerExit(Collider other)
	{
		if((other.gameObject.tag == "Enemy") || !(anim.GetCurrentAnimatorStateInfo(0).IsName("paw_swipe")))
		{
			hitEnemy = false;
		}
	}

	void Update ()
	{
		//increment timer to see if enough time has passed since previous attack
		timer = timer + Time.deltaTime;
		
		if((timer >= timeBetweenAttacks) && hitEnemy && (playerHealth.currentHealth > 0))
		{
			//Attack ();
			//Debug.Log ("enemy hit: " + enemy.gameObject);
			if(enemy.gameObject == GameObject.Find ("VacuumRoombaPos"))
			{
				vacHealth.TakeDamage(1);
			}
			else
			{
				if(enemy.gameObject != GameObject.Find ("Security Camera"))
				{
					enemyHealthScript = enemy.GetComponent<EnemyHealth>();
					enemyHealthScript.TakeDamage(1);
				}
			}

			timer = 0f;
		}
		
	}
	
	
//	void Attack ()
//	{
//		timer = 0f;
//		if(enemy = GameObject.Find ("VacuumRoombaPos"))
//		{
//			if (vacHealth.currentHealth > 0) 
//			{
//					vacHealth.TakeDamage (attackDamage);		
//			} 
//		}
//		if (enemy = GameObject.Find ("robot")) {
//
//		}
//
//	}
}
