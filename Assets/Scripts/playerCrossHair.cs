using UnityEngine;
using System.Collections;

public class playerCrossHair : MonoBehaviour {
	Animator anim;
	Camera camera;
	Ray cam_ray;
	RaycastHit cam_target;
	int interactMask;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		interactMask = LayerMask.GetMask ("Interactable");
		anim.SetBool("catCross",false);
		camera = Camera.main;
		//animation["normalCrossHair"].speed = 10;
		//animation["catCrossHair"].speed = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Screen.showCursor = false;
		cam_ray.origin = camera.transform.position;
		cam_ray.direction = camera.transform.forward;
		//anim.SetTrigger("catCross");
		if(Physics.Raycast(camera.transform.position, camera.transform.forward, out cam_target, 50f))
		{
			//Transform dummy;
			if(cam_target.transform.tag == "Interactable")
			{
				//Debug.Log ("interact");
				anim.SetBool("catCross",true);
			}
			else if(cam_target.transform.tag == "Untagged")
			{
				//Debug.Log ("untagged");
				anim.SetBool("catCross",false);
			}
			else
			{
				//Debug.Log (cam_target.transform.tag);
			}
		}
	}
}
