using UnityEngine;
using System.Collections;

public class PlayerSwipe : MonoBehaviour {

	public int damagePerSwipe = 1;
	PlayerPaw paw;
	float timer;
	PlayerShooting shootingScript;
	Animator anim;
	int swipeHash = Animator.StringToHash ("swipe");

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		paw = GameObject.Find ("Main Camera").GetComponent<PlayerPaw> ();
		shootingScript = GameObject.Find ("Main Camera").GetComponent<PlayerShooting> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//paw = GameObject.Find ("Main Camera").GetComponent<PlayerPaw> ();


			if (Input.GetButton ("Fire1") && anim.GetCurrentAnimatorStateInfo(0).IsName("idle")) 
			{
				if(paw.is_toast)
				{
					if(shootingScript.shootingTimer <= 0)
					{
						anim.SetTrigger(swipeHash);
					}
				}
				else
				{
					anim.SetTrigger(swipeHash);
				}	

			}


	}
}
