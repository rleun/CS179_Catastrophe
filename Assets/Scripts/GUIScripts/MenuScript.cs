using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	//public GameObject go;

	//void Start(){

	//	go = GameObject.Find ("Menu");
	//}
	public void Start_Button()
	{
	//	go.SetActive (false);
		Application.LoadLevel ("CatPawScene");		
			Debug.Log ("Hello");

	}
	public void Instr_Button()
	{
		//	go.SetActive (false);
		Application.LoadLevel ("InstructionMenu");		
		Debug.Log ("Hello");
		
	}
}
