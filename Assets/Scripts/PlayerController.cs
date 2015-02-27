using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	
	
	//public variable to make all changes in editor
	public float speed;
	
	//Check for player input at every frame
	void Update()//player actions
	{
		//ctrl + ' to search for term on Unity website
		//Input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//Use these to add forces to rigid body and move the player object
		//RigidBody
		rigidbody.AddForce (moveHorizontal*speed*Time.deltaTime, 0, moveVertical*speed*Time.deltaTime);
		//Alternatively
		/*	Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		 *  rigidbody.AddForce(movement);
		 */ 
		
		//Use speed to make movement better
		
	}
	void FixedUpdate()//physics update
	{
	}
}
