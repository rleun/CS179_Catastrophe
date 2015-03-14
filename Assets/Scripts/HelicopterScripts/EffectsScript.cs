using UnityEngine;
using System.Collections;

public class EffectsScript : MonoBehaviour {

	public GameObject CustomExplosion;
	float CoutDown = 1f;
	Vector3 position;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		CoutDown -= Time.deltaTime;
		position = transform.position;
		position.y = 4.7f;

		if(CoutDown <= 0)
		{
			GameObject explosion = Instantiate (CustomExplosion, transform.position, transform.rotation) as GameObject;
			explosion.transform.position = position;

			explosion.rigidbody.AddForce(transform.forward * 10f);
			Destroy (explosion, 4f);
			CoutDown = 1f;
		}

	}
}
