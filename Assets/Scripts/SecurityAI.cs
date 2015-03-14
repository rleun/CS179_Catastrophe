using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SecurityAI : MonoBehaviour {
	
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth RobotHealth;
	public GameObject LaserBolt;
	public Transform LaserSpawn;
	//Enemy Health UI
	public GameObject EnemyHealthObject;
	public Text DisplayName;
	public string EnemyName;
	public int currentHealth;
	public Slider healthSlider;
	public float MaxDistance = 30;
	bool isDead = false;
	bool damaged = false;
	float nextAttackTime = 0;

	public float CurrentDistance;
	Transform PlayerPosition;
	public bool PlayerWithInRange;

	bool hasPlayedDeath = false;
	public ParticleSystem deathParticle;

	EnemyHealth securityHealth;


	// Use this for initialization
	void Awake () {
		
		// Set the initial health of the player.
		//Set Enemy's name
		player = GameObject.Find("First Person Controller");
		RobotHealth = GameObject.FindGameObjectWithTag ("Robot").GetComponent<EnemyHealth>();
		DisplayName.text = EnemyName;
		securityHealth = GetComponent<EnemyHealth> ();
		healthSlider.value = securityHealth.currentHealth;

		PlayerPosition = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = securityHealth.currentHealth;
		//player alive or not alive
		isDead = securityHealth.currentHealth > 0 ? false : true;

		if(RobotHealth.currentHealth <= 0 && !isDead)
		{
			//Enemy move to and attack player
		//	if(!isDead)
		//	{
				//attack player
				Attack();
				CurrentDistance = Vector3.Distance (PlayerPosition.position, transform.position);
				PlayerWithInRange = CurrentDistance <= MaxDistance;
				
				//within  enemy's range
				if(PlayerWithInRange)
				{
					
					//Show healthbar
					EnemyHealthObject.SetActive(true);
				}
				else
				{
					EnemyHealthObject.SetActive(false);
				}
			}
			else
			{
				EnemyHealthObject.SetActive(false);
				if(!hasPlayedDeath)
				{
					Debug.Log("security ded");
					ParticleSystem bigBang = Instantiate(deathParticle,new Vector3(-4.23f,12.74f,-47.69f), Quaternion.identity) as ParticleSystem;
					bigBang.Play();
					Destroy(bigBang, 1f);
					hasPlayedDeath = true;
					//gameObject.SetActive(false);
				}
			}
		}
	

	void Attack()
	{
		nextAttackTime = nextAttackTime + Time.deltaTime;
		//Debug.Log ("attacking");
		if(nextAttackTime > 3)
		{
			player.GetComponent<MouseLook>().sensitivityX = 15f;
			player.GetComponent<MouseLook>().sensitivityX = 15f;
			//Do damage
			GameObject projectile = Instantiate(LaserBolt, LaserSpawn.position, LaserSpawn.rotation) as GameObject;
			projectile.rigidbody.velocity = transform.forward * 10f;

			nextAttackTime = 0;
		}
	}
}
