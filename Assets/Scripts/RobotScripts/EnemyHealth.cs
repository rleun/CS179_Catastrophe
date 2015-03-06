using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	
	Animator anim;

	SphereCollider sphereCollider;
	ParticleSystem pSystem;
	bool isDead;

	private float startTime;
	private float elapsedTime;
	GameObject cat_paw_main;

	EnemyAI enemyAIScript;
	
	
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		currentHealth = startingHealth;
		sphereCollider = GetComponent <SphereCollider> ();
		pSystem = GetComponent <ParticleSystem> ();
		cat_paw_main = GameObject.Find ("Main Camera");
		startTime = Time.time;
		enemyAIScript = GetComponent <EnemyAI> ();
		
	}
	
	void Start()
	{
		
	}
	
	void Update ()
	{
		elapsedTime = Time.time;

		if (!isDead && (elapsedTime - startTime > 44f) ) 
		{
			startTime = elapsedTime;
		}
		
	}
	
	
	public void TakeDamage (int amount)
	{
		if(isDead)
		{
			return;
		}
		
		PlayerPaw currentPaw = cat_paw_main.GetComponent<PlayerPaw> ();
		if(currentPaw.is_main)
		{
			//Get Particle System for onHit
			//GameObject vacuumParticle = GameObject.Find ("RobotHitParticle");
			pSystem = GetComponent<ParticleSystem> ();
			pSystem.Play ();
		}
		
		
		
		currentHealth -= amount;
		enemyAIScript.currentHealth = enemyAIScript.currentHealth - 1;
		Debug.Log ("Robot takes " + amount + " damage. HP left: " + currentHealth);
		
		if(currentHealth <= 0)
		{
			Debug.Log("Robot Dead");
			Die ();
		}
	}
	
	
	void Die ()
	{
		isDead = true;
		
//		sphereCollider.isTrigger = true;
		
		// anim.SetTrigger ("gameWin");
		
		

		//Show victory text
		//		victoryText.SetActive(true);
	}

}
