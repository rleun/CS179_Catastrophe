using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {
	GameObject Timer;
	int seconds;
	int minutes = 5;
	float timeLeft;
	GameObject gameoverText;
	GameObject player;
	PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		Timer = new GameObject ();
		Timer.AddComponent<GUIText> ();
		Timer.transform.position = new Vector3 (0.7f,1.0f,0.0f);
		Timer.guiText.fontSize = 30;
		Timer.guiText.color = Color.yellow;
		timeLeft= 60* (float)minutes;
		minutes = (int)timeLeft / 60;
		Timer.guiText.text = "Timer: " + minutes + ":" + "00";
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timeLeft > 0) 
		{
			timeLeft -= Time.deltaTime;	
			minutes = (int)timeLeft / 60;
			seconds = (int) timeLeft % 60;
			if(seconds >= 10)
			{
				Timer.guiText.text = "Timer: " + minutes + ":" + seconds;
			}
			else 
			{
				Timer.guiText.text = "Timer: " + minutes + ":" + "0" + seconds;
			}
		}
		else
		{
			playerHealth.currentHealth = 0;
		}
	}
}
