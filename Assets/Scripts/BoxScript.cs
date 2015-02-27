using UnityEngine;
using System.Collections;

public class BoxScript : MonoBehaviour {

	GameObject player;
	Transform player_loc;
	PlayerHealth playerHealth;
	float dist = 20;
	Animator anim;
	float timer = 10;
	// Use this for initialization
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		player_loc = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		playerHealth = player.GetComponent <PlayerHealth> ();
		anim.SetBool ("boxTime",false);
		//TODO:
		//playerCuriosity = player.GetComponent <PlayerCuriosity> ();
	}

	//Check for cat entering box
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			anim.SetBool("catInBox",true);
		}
	}
	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			anim.SetBool("catInBox",false);
		}
	}
	// Update is called once per frame
	void Update () 
	{
		bool catInRange = Vector3.Distance(player_loc.position,transform.position) < dist;
			anim.SetBool("catInRange",catInRange);
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("boxClosed"))
		{
			timer -= Time.deltaTime;
			//player health component used as placeholder for curiousity meter to be implemented
			if(playerHealth.currentHealth < 9 && anim.GetBool("boxTime") == false)
			{
				playerHealth.currentHealth+=1;
			}
			if(timer <= 0)
			{
				anim.SetBool ("boxTime",true);

				timer = 10;
			}
		}


	}
}
