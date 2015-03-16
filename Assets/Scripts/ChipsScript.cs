using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChipsScript : MonoBehaviour {

	GameObject Player;
	PlayerHealth PlayerHealth;
	int Number;
	GameObject nachos;
	Animator canvasAnim;

	Transform player;
	float dist = 3;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nachos = GameObject.Find ("nachoText");
		canvasAnim = GameObject.Find ("Canvas").GetComponent<Animator> ();
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
				nachos.GetComponent<Text>().text = "Life -2";
				canvasAnim.SetTrigger ("nachos");
				Debug.Log("acti chips");

				
			}
			else
			{
				PlayerHealth.currentHealth = PlayerHealth.currentHealth+2;
				nachos.GetComponent<Text>().text = "Life +2";
				canvasAnim.SetTrigger ("nachos");
				Debug.Log("acti chips");
			}
			Destroy(gameObject);
		}
	}
	

}
