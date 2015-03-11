using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	GameObject Player;
	Transform PlayerPosition;	//	get player cat position
	PlayerHealth playerHealth;
	NavMeshAgent nav;           //	nav mesh agent.
	float CurrentDistance;
	
	//Enemy Health UI
	public GameObject EnemyHealthObject;
	public Text DisplayName;
	public string EnemyName;
	public int currentHealth;
	public Slider healthSlider;
	public float MaxDistance = 20;
	bool isDead = false;
	bool damaged = false;
	float nextAttackTime = 0;

	// Use this for initialization
	void Awake () {

		Player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = Player.GetComponent<PlayerHealth> ();
		PlayerPosition = Player.transform;
		
		nav = GetComponent <NavMeshAgent> ();

		// Set the initial health of the player.
		//Set Enemy's name
		DisplayName.text = EnemyName;
		healthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = currentHealth;
		//player alive or not alive
		isDead = playerHealth.currentHealth > 0 ? false : true;

		//Enemy move to and attack player
		if(!isDead)
		{
			//detects and goes toward player cat
			MoveToPlayer ();
			//attack player
			Attack();
		}
	}


	void MoveToPlayer()
	{
		CurrentDistance = Vector3.Distance (PlayerPosition.position, transform.position);
		bool PlayerWithInRange = CurrentDistance <= MaxDistance;

		//within  enemy's range
		if(PlayerWithInRange)
		{

			//Show healthbar
			EnemyHealthObject.SetActive(true);
	
			//NAV mesh finds a path to player
			if(CurrentDistance > 3)
			{
				nav.enabled = true;
				nav.SetDestination(PlayerPosition.position);
			}
			else
			{
				nav.enabled = false;
			}

		}
		else
		{
			//Display healthbar
			EnemyHealthObject.SetActive(false);

			nav.enabled = false;
		}
	}

	void Attack()
	{
		nextAttackTime = nextAttackTime + Time.deltaTime;
		int AttackDamage = 1;

		if(nextAttackTime > 1 && CurrentDistance < 2.5)
		{
			//Do damage
			playerHealth.TakeDamage(AttackDamage);
			nextAttackTime = 0;
		}
	}
}
