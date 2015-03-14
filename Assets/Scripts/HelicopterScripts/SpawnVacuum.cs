using UnityEngine;
using System.Collections;

public class SpawnVacuum : MonoBehaviour {

	GameObject helicopter;
	EnemyHealth helicopterHealth;
	// Use this for initialization
	void Start () {
		helicopter = GameObject.Find ("helicpoter");

	}
	
	// Update is called once per frame
	void Update () {
		if(helicopter.GetComponent<EnemyHealth>().isDead)
		{
			GameObject.Find("VacuumRoombaPos").SetActive(true);
		}
	}
}
