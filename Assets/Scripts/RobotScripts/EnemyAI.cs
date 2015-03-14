using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	GameObject Player;
	Transform PlayerPosition;	//	get player cat position
	PlayerHealth playerHealth;
	NavMeshAgent nav;           //	nav mesh agent.
	public float CurrentDistance;
	public bool PlayerWithInRange;
	public int MaxAttackRange;
	
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

	public ParticleSystem deathParticle;
	bool hasPlayedDeath = false;

	bool vacuumSpawn = false;

	//public GameObject CustomExplosion;

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

	void Start() {
		//Instantiate (CustomExplosion, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = currentHealth;
		//player alive or not alive
		isDead = currentHealth > 0 ? false : true;

		//Enemy move to and attack player
		if(!isDead)
		{
			//detects and goes toward player cat
			MoveToPlayer ();
			//attack player
			Attack();
		}
		else
		{
			EnemyHealthObject.SetActive(false);
			if(!hasPlayedDeath)
			{
				Debug.Log("hasplayeddeath");
				ParticleSystem bigBang = Instantiate(deathParticle,transform.position, transform.rotation) as ParticleSystem;
				bigBang.Play();
				Destroy(bigBang, 5);
				foreach(GameObject pclone in GameObject.FindGameObjectsWithTag("Particle"))
				{
					if(pclone.name == "Big Bang(Clone)")
					{
						Destroy(pclone,5);
					}
				}
				hasPlayedDeath = true;
				//transform.position = new Vector3(transform.position.x, transform.position.y, -360f);
			}


			if(gameObject.name == "helicopter" && vacuumSpawn == false)
			{
				GameObject vac = GameObject.Find ("VacuumRoombaPos");
				NavMeshAgent navMesh = vac.GetComponent<NavMeshAgent>();
				navMesh.enabled = false;
				vac.transform.position = new Vector3(vac.transform.position.x, vac.transform.position.y, 105f);
				navMesh.enabled = true;
				vacuumSpawn = true;
			}

			if(gameObject.name == "robot")
			{
				if(!GameObject.Find("Holy Shine").GetComponent<ParticleSystem>().isPlaying)
				{
					GameObject.Find("Holy Shine").GetComponent<ParticleSystem>().Play();
				}
				GameObject toast = GameObject.Find ("toaster");
				toast.transform.position = new Vector3(toast.transform.position.x, toast.transform.position.y, -6.5f);
			}
			//gameObject.GetComponentInChildren<ParticleSystem>().Play();
		}
	}


	void MoveToPlayer()
	{
		CurrentDistance = Vector3.Distance (PlayerPosition.position, transform.position);
		PlayerWithInRange = CurrentDistance <= MaxDistance;

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

		if(nextAttackTime >= 2.8 && CurrentDistance < MaxAttackRange)
		{
			//Do damage
			playerHealth.TakeDamage(AttackDamage);
			nextAttackTime = 0;
		}

	}
}
