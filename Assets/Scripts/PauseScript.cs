using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {
	// Use this for initialization
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
	void togglePause()
	{
		if(!paused)
		{
			player.GetComponent<MouseLook>().enabled = false;
			camera.GetComponent<MouseLook>().enabled = false;
			Time.timeScale = 0;
			Screen.lockCursor = false;
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
