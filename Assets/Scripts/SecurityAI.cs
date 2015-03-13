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
	public float MaxDistance = 20;
	bool isDead = false;
	bool damaged = false;
	float nextAttackTime = 0;
	
	// Use this for initialization
	void Awake () {
		
		// Set the initial health of the player.
		//Set Enemy's name
		player = GameObject.Find("First Person Controller");
		RobotHealth = GameObject.FindGameObjectWithTag ("Robot").GetComponent<EnemyHealth>();
		DisplayName.text = EnemyName;
		healthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = currentHealth;
		//player alive or not alive
		isDead = currentHealth > 0 ? false : true;
		
		//Enemy move to and attack player
		if(!isDead && RobotHealth.currentHealth <= 0)
		{
			//attack player
			Attack();
		}
		else
		{
			EnemyHealthObject.SetActive(false);
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
