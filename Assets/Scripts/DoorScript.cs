using UnityEngine;
using System.Collections;
//This function will control when the door opens 
//The door will open when a certain enemy has been defeated
public class DoorScript : MonoBehaviour {
	//Trigger is the enemy GameObject
	public GameObject Trigger;
	EnemyHealth enemyHealth;
	Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		enemyHealth = Trigger.GetComponent<EnemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyHealth.currentHealth <= 0) {
			anim.SetBool("EnemyDead", true);
		}
	}
}
