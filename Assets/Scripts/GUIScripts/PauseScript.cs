using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {
	GameObject player;
	GameObject camera;
	bool paused = false;
	GameObject pauseTxt;

	void InitializePauseTxt()
	{
		pauseTxt = new GameObject ();
		pauseTxt.AddComponent<GUIText> ();
		pauseTxt.transform.position = new Vector3 (0.45f,1.0f,0.0f);
		pauseTxt.guiText.fontSize = 30;
		pauseTxt.guiText.text = "Pause";
	}
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		player = GameObject.Find ("First Person Controller");
		camera = GameObject.Find ("Main Camera");
		InitializePauseTxt();
		pauseTxt.guiText.enabled = false;
		Time.timeScale = 1;
	}


	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			togglePause();
		}
	}

	//Display the buttons on pause screen
	void OnGUI()
	{
		if (paused) 
		{
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 10, 100, 30), "Quit")) 
			{
				Application.LoadLevel ("MenuScene");
				Debug.Log ("Quit");		
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 30), "Restart")) 
			{
				Application.LoadLevel("CatPawScene");
				Debug.Log ("Restart");		
			}
		}
	}

	//Switch between pause and unpasued when 'P' is pressed
	void togglePause()
	{
		if(!paused)
		{
			player.GetComponent<MouseLook>().enabled = false;
			camera.GetComponent<MouseLook>().enabled = false;
			Time.timeScale = 0;
			Screen.lockCursor = false;
			Screen.showCursor = true;
			paused = true;
			pauseTxt.guiText.enabled = true;
			Debug.Log("is Pause");
		}
		else 
		{
			Time.timeScale = 1;
			player.GetComponent<MouseLook>().enabled = true;
			camera.GetComponent<MouseLook>().enabled = true;			
			Screen.lockCursor = true;
			pauseTxt.guiText.enabled = false;
			Debug.Log(" is unPause");
			paused = false;

		}
	}
}
