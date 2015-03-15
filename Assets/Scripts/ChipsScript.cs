using UnityEngine;
using System.Collections;

public class ChipsScript : MonoBehaviour {

	GameObject Player;
	PlayerHealth PlayerHealth;
	int Number;

	Transform player;
	float dist = 3;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		PlayerHealth = Player.GetComponent<PlayerHealth> ();

		bool withinRange = Vector3.Distance(player.position,transform.position) < dist;
		if(withinRange && Input.GetKey(KeyCode.E))
		{
			Number = Random.Range(1,10);
			if(Number <= 5)
			{
				PlayerHealth.TakeDamage(2);
				
			}
			else
			{
				PlayerHealth.currentHealth = PlayerHealth.currentHealth+2;
			}
			Destroy(gameObject);
		}
	}
	

}
