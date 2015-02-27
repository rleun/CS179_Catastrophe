using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour {

	public int Lives;
	public Text LifeLabel;
	public GameObject gameoverText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		LifeLabel.text = "Life Left: " + Lives;

		if(Lives == 0)
		{
			//Show gameover text
			gameoverText.SetActive(true);
		}
	}

}
