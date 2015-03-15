using UnityEngine;
using System.Collections;

public class ToasterScript : MonoBehaviour {

	Transform player;
	float dist = 3;
	Animator anim;
	float timer = 5;
	public bool changeToToast = false;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () 
	{
		bool withinRange = Vector3.Distance(player.position,transform.position) < dist;
		if(withinRange && Input.GetKey(KeyCode.E) && anim.GetCurrentAnimatorStateInfo(0).IsName ("idle"))
		{
			anim.SetTrigger("toast");
		}
		else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Toast"))
		{
			timer -= Time.deltaTime;
			if(timer <= 0)
			{
				anim.SetTrigger ("pop");
			}
		}
		else if(anim.GetCurrentAnimatorStateInfo(0).IsName ("Pick up toast") && Input.GetKey (KeyCode.E) && withinRange)
		{
			//switch cat paw
			anim.SetTrigger("pickedUpToast");
			timer = 5;
			changeToToast = true;
		}

	}
}
