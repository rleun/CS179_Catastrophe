using UnityEngine;
using System.Collections;

public class LaserBoltMove : MonoBehaviour 
{
	public float speed;
	GameObject player;
	GameObject security_camera;
	bool mode1 = false;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find ("First Person Controller");
		security_camera = GameObject.Find ("security_cam");
		mode1 = security_camera.GetComponent<EnemyHealth> ().currentHealth > 5;
		if (mode1) 
		{
			GameObject.Find ("Orange").SetActive(false);
		}
		rigidbody.velocity = transform.forward *speed;
	}

	//When laser bolt hits something, deal damage to player if player.
	//Destroy laser bolt
	void OnCollisionEnter(Collision other)
	{
//		Debug.Log (other.gameObject.name);
		if (other.gameObject.name == "cat_paw_animated" || other.gameObject.name == "First Person Controller" || other.gameObject.name == "cat_paw_toast") 
		{
			if(mode1)
			{
				player.GetComponent<PlayerHealth>().TakeDamage(1);
			}
			else
			{
				player.GetComponent<MouseLook>().sensitivityX = 1f;
				player.GetComponent<MouseLook>().sensitivityX = 1f;
				player.GetComponent<PlayerHealth>().TakeDamage(1);
			}
			Destroy(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
