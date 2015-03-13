using UnityEngine;
using System.Collections;

public class PlayerSwipe : MonoBehaviour {

	public int damagePerSwipe = 1;
	float timer;

	Animator anim;
	int swipeHash = Animator.StringToHash ("swipe");

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton ("Fire1")) 
		{
			anim.SetTrigger(swipeHash);



		}

	}
}
