using UnityEngine;
using System.Collections;

public class ChipsScript : MonoBehaviour {

	GameObject Player;
	PlayerHealth PlayerHealth;
	int Number;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		PlayerHealth = Player.GetComponent<PlayerHealth> ();
	}
	
	void OnTriggerEnter (Collider col)
	{

		if(col.name == "First Person Controller" || col.name == "cat_paw_animated")
		{	
			Number = Random.Range(1,10);
			if(Number <= 6)
			{
				PlayerHealth.currentHealth = PlayerHealth.currentHealth-2;
			}
			else
			{
				PlayerHealth.currentHealth = PlayerHealth.currentHealth+2;
			}
			Destroy(gameObject);
		}
	}
}
