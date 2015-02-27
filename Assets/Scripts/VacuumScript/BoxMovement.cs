using UnityEngine;
using System.Collections;

public class BoxMovement : MonoBehaviour {
	Transform player;
	PlayerHealth playerHealth;
	VacuumHealth enemyHealth;
	NavMeshAgent vac_nav;
	ParticleSystem pSystem;
	Animator anim;
	Animation animation;
	float dist = 20;
	bool aggro_once = false;
	
	//	public Animator animController;
	public NavMeshAgent navAgent;
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent <Animator> ();
		animation = GetComponent<Animation> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <VacuumHealth> ();
		vac_nav = GetComponent <NavMeshAgent> ();
		anim.applyRootMotion = false;

		
	}

	
	void Update ()
	{
		bool withinRange = Vector3.Distance(player.position,transform.position) < dist;
		if(withinRange && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 )
		{
			
			vac_nav.SetDestination (player.position);

		}
		else
		{

			vac_nav.Stop();
		}
	}
}