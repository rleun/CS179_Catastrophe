using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	GameObject Player;
	PlayerHealth PlayerHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Player = GameObject.Find ("First Person Controller");
		PlayerHealth = Player.GetComponent<PlayerHealth> ();
	}

	void OnTriggerEnter (Collider col)
	{
		if(col.name == "First Person Controller" || col.name == "cat_paw_animated")
		{

			PlayerHealth.TakeDamage(1);
			Destroy(gameObject);
		}
	}
}
