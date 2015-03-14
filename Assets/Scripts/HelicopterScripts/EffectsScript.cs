using UnityEngine;
using System.Collections;

public class EffectsScript : MonoBehaviour {

	public GameObject CustomExplosion;
	public GameObject Burning;
	GameObject Player;
	EnemyHealth EnemyHealth;
	bool IsBurning = false;

	float CoutDown = 1f;
	Vector3 position;

	// Use this for initialization
	void Start () {
		EnemyHealth = GetComponent<EnemyHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		CoutDown -= Time.deltaTime;
		position = transform.position;
		position.y = 4.7f;

		if(CoutDown <= 0 && EnemyHealth.currentHealth > 0)
		{
			GameObject explosion = Instantiate (CustomExplosion, transform.position, transform.rotation) as GameObject;
			explosion.transform.position = position;

			explosion.rigidbody.AddForce(transform.forward * 10f);
			Destroy (explosion, 4f);
			CoutDown = 1f;
		}

		if(!IsBurning && EnemyHealth.currentHealth <= 0)
		{
			GameObject Burn = Instantiate (Burning, transform.position, transform.rotation) as GameObject;
			position.x -= 4;
			Burn.transform.position = position;
			Debug.Log("Got here");
			IsBurning = true;
		}

	}
}
