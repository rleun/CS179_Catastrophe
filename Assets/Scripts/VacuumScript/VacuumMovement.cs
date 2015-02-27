using UnityEngine;
using System.Collections;

public class VacuumMovement : MonoBehaviour
{
	Transform player;
	PlayerHealth playerHealth;
	VacuumHealth enemyHealth;
	NavMeshAgent vac_nav;
	ParticleSystem pSystem;
	Animator anim;
	float dist = 20;
	bool aggro_once = false;
	
	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent <Animator> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <VacuumHealth> ();
		vac_nav = GetComponent <NavMeshAgent> ();
		anim.applyRootMotion = false;

		GameObject cyclone = GameObject.Find("Cyclone");
		pSystem = cyclone.GetComponent<ParticleSystem> ();

	}
	
	
	void Update ()
	{
		bool withinRange = Vector3.Distance(player.position,transform.position) < dist;
		if(withinRange && enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 )
		{
			if(!pSystem.isPlaying)
			{
				pSystem.Play();
			}
//			if(anim.GetCurrentAnimatorStateInfo(0).IsName ("vacIdle"))
//			{
//				anim.SetTrigger("Aggro");
//			}
	
			vac_nav.SetDestination (player.position);
			
			//anim.rootPosition = vac_nav.desiredVelocity;
			//anim.rootPosition = vac_nav.desiredVelocity;
		}
		else
        {
//			if(anim.GetCurrentAnimatorStateInfo(0).IsName ("Aggroed"))
//			{
//				anim.SetTrigger("Unaggro");
//			}
			//pSystem.Stop();
			vac_nav.Stop();
        }
	}
}
