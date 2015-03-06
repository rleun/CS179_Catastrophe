using UnityEngine;
using System.Collections;

public class CanvasScript : MonoBehaviour {

	Animator anim;
	public PlayerHealth playerHealth;
	public VacuumHealth vacuumHealth;
	public float restartDelay = 5f;
	GameObject player;
	GameObject vacuum;

	float restartTimer;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		vacuum = GameObject.Find ("VacuumRoombaPos");
		playerHealth = player.GetComponent<PlayerHealth> ();
		vacuumHealth = vacuum.GetComponent<VacuumHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger("gameOver");

			restartTimer += Time.deltaTime;

			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		if(vacuumHealth.currentHealth <= 0)
		{
			anim.SetTrigger("gameWin");
			
			restartTimer += Time.deltaTime;
			
			if(restartTimer >= restartDelay)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
