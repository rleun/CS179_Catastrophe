using UnityEngine;
using System.Collections;

public class VacuumMovement : MonoBehaviour
{
	Transform player;
	PlayerHealth playerHealth;
	VacuumHealth enemyHealth;
	NavMeshAgent vac_nav;
	ParticleSystem pSystem;
	ParticleSystem finalPSystem;
	ParticleSystem spinPSystem;
	ParticleSystem meteorPSystem;
	Animator anim;
	Animation animation;
	float dist = 30;
	bool aggro_once = false;
	GameObject vacuum;
	public Animator animController;
	public NavMeshAgent navAgent;
	Rigidbody rigidbody;
	float attackTimer = 3f; 
	int number;
	int meteorAttack = 3;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GameObject.Find ("VacuumRoomba").GetComponent <Animator> ();
		animation = GetComponent<Animation> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <VacuumHealth> ();
		vac_nav = GetComponent <NavMeshAgent> ();
		anim.applyRootMotion = false;
		vacuum = GameObject.Find ("VacuumRoombaPos");
		GameObject cyclone = GameObject.Find("Cyclone");
		pSystem = cyclone.GetComponent<ParticleSystem> ();
		finalPSystem = GameObject.Find ("Big Bang").GetComponent<ParticleSystem> ();
		spinPSystem = GameObject.Find ("Lightning Spark").GetComponent<ParticleSystem> ();
		meteorPSystem = GameObject.Find ("Meteor Storm").GetComponent<ParticleSystem> ();
		rigidbody = GetComponent<Rigidbody>();
		animation = GetComponent<Animation> ();

	}


	void Update ()
	{
		bool withinRange = Vector3.Distance(player.position,transform.position) < dist;

		if(anim.GetCurrentAnimatorStateInfo(0).IsName ("vacIdle") && withinRange && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 )
		{
			anim.SetTrigger("Aggro");
			if(!pSystem.isPlaying)
			{
				pSystem.Play();
			}
			anim.SetBool("Unaggro", false);
			attackTimer = 3f;
		}
		else if(anim.GetCurrentAnimatorStateInfo(0).IsName ("aggroed"))
		{
			if(withinRange && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 )
			{
				vac_nav.SetDestination (player.position);
				if(attackTimer <= 0)
				{
					number = Random.Range(0,3);
					//Debug.Log("number = " + number);
					anim.SetInteger("attack",number);
					//anim.SetInteger("attack", -1);

				}
				else
				{
					attackTimer -= Time.deltaTime;
					finalPSystem.Stop();
					spinPSystem.Stop();
				}
			}
			else
			{
				vac_nav.Stop ();
				attackTimer = 3f;
				anim.SetBool("Unaggro", true);
			}

		}
		else if(anim.GetCurrentAnimatorStateInfo(0).IsName ("reset_attack"))
		{
			attackTimer = 3f;
			anim.SetInteger("attack", -1);
			anim.SetTrigger("reset");
		}
		else if(anim.GetCurrentAnimatorStateInfo(0).IsName ("roomba_finalform"))
		{
			if(!finalPSystem.isPlaying)
			{
				finalPSystem.Play();
			}
			if(!meteorPSystem.isPlaying)
			{
				meteorPSystem.Play();
			}
		}
		else if(anim.GetCurrentAnimatorStateInfo(0).IsName ("roomba_spin"))
		{
			if(!spinPSystem.isPlaying)
			{
				spinPSystem.Play();

			}
		}
	}
}
