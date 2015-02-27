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

		if((other.gameObject == enemy) && (anim.GetCurrentAnimatorStateInfo(0).IsName("paw_swipe")))
		{
			hitEnemy = true;
		}
		else if(!(anim.GetCurrentAnimatorStateInfo(0).IsName("paw_swipe")))
		{
			hitEnemy = false;
		}

	}
	
	void OnTriggerExit(Collider other)
	{
		if((other.gameObject == enemy) || !(anim.GetCurrentAnimatorStateInfo(0).IsName("paw_swipe")))
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
			Attack ();
		}
		
	}
	
	
	void Attack ()
	{
		timer = 0f;
		if (vacHealth.currentHealth > 0) 
		{
				vacHealth.TakeDamage (attackDamage);		
		} 
	}
}
