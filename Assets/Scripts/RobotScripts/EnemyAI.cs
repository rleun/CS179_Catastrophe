using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	Transform CatPosition;	//	get player cat position
	NavMeshAgent nav;           //	nav mesh agent.
	public float MaxDistance = 20;
	float CurrentDistance;
	
	//Enemy Health
	public GameObject EnemyHealthObject;
	public Text DisplayName;
	public int startingHealth = 9;
	public string EnemyName;
	public int currentHealth;
	public Slider healthSlider; 
	bool isDead;
	bool damaged;

	// Use this for initialization
	void Awake () {
		CatPosition = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();

		// Set the initial health of the player.
		currentHealth = startingHealth;
		//Set Enemy's name
		DisplayName.text = EnemyName;
	}
	
	// Update is called once per frame
	void Update () {

		//detects and goes toward player cat
		MoveToPlayer ();
	}


	void MoveToPlayer()
	{
		CurrentDistance = Vector3.Distance (CatPosition.position, transform.position);
		bool PlayerWithInRange = CurrentDistance <= MaxDistance;

		//within  enemy's range
		if(PlayerWithInRange)
		{

			//Show healthbar
			EnemyHealthObject.SetActive(true);
	
			//NAV mesh finds a path to player
			if(CurrentDistance > 3)
			{
				nav.enabled = true;
				nav.SetDestination(CatPosition.position);
			}
			else
			{
				nav.enabled = false;
			}
				
		}
		else
		{
			//Display healthbar
			EnemyHealthObject.SetActive(false);

			nav.enabled = false;
		}
	}
}
