using UnityEngine;
using System.Collections;

public class InstructionScript : MonoBehaviour {

	// Use this for initialization

	public void Exit_Button () 
	{
		Application.LoadLevel("MenuScene");
	}

	public void Next_Button()
	{
		Application.LoadLevel("ItemScene");

	}

	public void Back_Button()
	{
		Application.LoadLevel("InstructionMenu");

	}

}
