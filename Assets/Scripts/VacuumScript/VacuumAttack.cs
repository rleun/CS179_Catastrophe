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
	Animator anim;

	public BoxCollider finalBox;
	public BoxCollider spinBox;
	public SphereCollider meshBox;

	float finalTimer = 3f;
	float spinTimer = 3.18f;

	bool inFinalHitbox = false;
	bool inSpinHitbox = false;
	bool isHit = false;

	Transform playerPosition;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		vacuum = GameObject.FindGameObjectWithTag ("Enemy");
		//Change later to encompase all enemies
		vacHealth = vacuum.GetComponent <VacuumHealth> ();
		anim = GameObject.Find ("VacuumRoomba").GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
//        if(other.gameObject == player)
//        {
//            hitPlayer = true;
//        }
    }


    void OnTriggerExit (Collider other)
    {
//        if(other.gameObject == player)
//        {
//            hitPlayer = false;
//        }
//		if(other == finalBox)
//		{
//			inFinalHitbox = false;
//		}
//		if(other == spinBox)
//		{
//			inSpinHitbox = false;
//		}
    }

	void OnTriggerStay( Collider other)
	{
//		if( (other == finalBox) && (anim.GetCurrentAnimatorStateInfo(0).IsName ("roomba_finalform")))
//		{
//			inFinalHitbox = true;
//		}
//
//		if( (other == spinBox) && (anim.GetCurrentAnimatorStateInfo(0).IsName ("roomba_spin")))
//		{
//			inSpinHitbox = true;
//		}
	}

    void Update ()
    {


		//increment timer to see if enough time has passed since previous attack
        timer = timer + Time.deltaTime;

		if(timer >= timeBetweenAttacks && meshBox.bounds.Contains(GameObject.Find ("First Person Controller").transform.position) && (vacHealth.currentHealth > 0))
        {
            Attack ();
        }

		if(anim.GetCurrentAnimatorStateInfo(0).IsName ("roomba_finalform"))
		{
			finalTimer -= Time.deltaTime;
			if((finalTimer <= 0) && finalBox.bounds.Contains(GameObject.Find ("First Person Controller").transform.position) && !isHit)
			{
					playerHealth.TakeDamage(attackDamage);
					isHit = true;
			}
		}

		if(anim.GetCurrentAnimatorStateInfo(0).IsName ("roomba_spin"))
		{
			spinTimer -= Time.deltaTime;
			if((spinTimer <= 0) && spinBox.bounds.Contains(GameObject.Find ("First Person Controller").transform.position) && !isHit)
			{
					playerHealth.TakeDamage(attackDamage);
					isHit = true;
			}
		}

		if(anim.GetCurrentAnimatorStateInfo(0).IsName ("aggroed"))
		{
			finalTimer = 3f;
			spinTimer = 3.18f;
			isHit = false;
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
