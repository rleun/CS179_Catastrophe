using UnityEngine;
using System.Collections;

public class VacuumAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1f;
    public int attackDamage = 1;


    GameObject player;
	GameObject vacuum;
    PlayerHealth playerHealth;
    VacuumHealth vacHealth;
    bool hitPlayer;
    float timer;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		vacuum = GameObject.FindGameObjectWithTag ("Enemy");
		//Change later to encompase all enemies
		vacHealth = vacuum.GetComponent <VacuumHealth> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            hitPlayer = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            hitPlayer = false;
        }
    }


    void Update ()
    {
		//increment timer to see if enough time has passed since previous attack
        timer = timer + Time.deltaTime;

        if(timer >= timeBetweenAttacks && hitPlayer && (vacHealth.currentHealth > 0))
        {
            Attack ();
        }

    }


    void Attack ()
    {
        timer = 0f;
		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage(attackDamage);		
		}
    }
}
