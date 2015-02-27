using UnityEngine;
using System.Collections;

public class PlayerPaw : MonoBehaviour {

	public bool is_main;
	public bool is_toast;

	GameObject paw_main;
	GameObject paw_toast;
	GameObject toaster;
	GameObject current_cat_paw;
	GameObject main_camera;

	Animator anim_current_paw;
	Animator paw_main_animator;
	Animator paw_toast_animator;

	float timer = 1f;
	bool main_changed = false;
	bool toast_changed = false;
	bool to_toast = false;
	bool to_main = true;

	MeshRenderer mesh;
	Animator cat_anim;
	BoxCollider cat_box_collider;
	PlayerSwipe cat_playerSwipe;

	ToasterScript tScript;
	PlayerShooting shootingScript;

	// Use this for initialization
	void Start () {
		is_main = true;
		is_toast = false;


		toaster = GameObject.Find ("toaster");
		tScript = toaster.GetComponent<ToasterScript> ();

		main_camera = GameObject.Find ("Main Camera");
		shootingScript = main_camera.GetComponent<PlayerShooting> ();

		paw_main = GameObject.Find ("cat_paw_animated");
		paw_toast = GameObject.Find ("cat_paw_toast");

		paw_main_animator = paw_main.GetComponent<Animator> ();
		paw_toast_animator = paw_toast.GetComponent<Animator> ();


		current_cat_paw = paw_main;
	}


	// Update is called once per frame
	void Update () {
		anim_current_paw = current_cat_paw.GetComponent<Animator> ();
		//Change to cat_paw_toast
		if(tScript.changeToToast)
		{
			if(!main_changed)
			{
				Debug.Log("to_toast");
				changePawToToast();
				is_toast = true;
				is_main = false;
			}
			tScript.changeToToast = false;
		}
		else if( shootingScript.changeToMain)
		{
			if(!toast_changed)
			{
				Debug.Log("to_main");
				changePawToMain();
				is_toast = false;
				is_main = true;
			}
			shootingScript.changeToMain = false;
		}


		if((to_toast) && (paw_main_animator.GetCurrentAnimatorStateInfo(0).IsName ("paw_down_done")))
		{
			//Disable current paw's components
			GameObject cat_paw_mesh = GameObject.Find("cat_paw_mesh");
			mesh = cat_paw_mesh.GetComponent<MeshRenderer>();
			mesh.enabled = false;

			cat_anim = paw_main.GetComponent<Animator>();
			//cat_anim.SetTrigger("reset");
			cat_anim.enabled = false;
			Debug.Log("anim = false");

			cat_box_collider = paw_main.GetComponent<BoxCollider>();
			cat_box_collider.enabled = false;

			cat_playerSwipe = paw_main.GetComponent<PlayerSwipe>();
			cat_playerSwipe.enabled = false;

			main_changed = false;
			to_toast = false;
		}

		if((to_main) && (paw_toast_animator.GetCurrentAnimatorStateInfo(0).IsName ("paw_down_toast_done")))
		{
			//Disable current paw's components
			GameObject cat_paw_toast_mesh = GameObject.Find("cat_paw_toast_mesh");
			mesh = cat_paw_toast_mesh.GetComponent<MeshRenderer>();
			mesh.enabled = false;
			
			cat_anim = paw_toast.GetComponent<Animator>();
			//cat_anim.SetTrigger("reset");
			cat_anim.enabled = false;
			
			cat_playerSwipe = paw_toast.GetComponent<PlayerSwipe>();
			cat_playerSwipe.enabled = false;
			
			GameObject main_camera = GameObject.Find ("Main Camera");
			PlayerShooting cat_shooting = main_camera.GetComponent<PlayerShooting> ();
			cat_shooting.enabled = false;

			toast_changed = false;
			to_main = false;
		}
	}

	void changePawToToast()
	{
		anim_current_paw.SetTrigger("change_paw");
		
		//Enable new paw's components
		GameObject cat_paw_toast_mesh = GameObject.Find("cat_paw_toast_mesh");
		mesh = cat_paw_toast_mesh.GetComponent<MeshRenderer>();
		mesh.enabled = true;
		
		cat_anim = paw_toast.GetComponent<Animator>();
		cat_anim.enabled = true;
		
		cat_playerSwipe = paw_toast.GetComponent<PlayerSwipe>();
		cat_playerSwipe.enabled = true;

		GameObject main_camera = GameObject.Find ("Main Camera");
		PlayerShooting cat_shooting = main_camera.GetComponent<PlayerShooting> ();
		cat_shooting.enabled = true;


		paw_toast_animator.SetTrigger("to_paw");
		current_cat_paw = paw_toast;
		main_changed = true;
		to_toast = true;
	}

	void changePawToMain()
	{
		anim_current_paw.SetTrigger ("change_paw");

		//Enable new paw's components
		GameObject cat_paw_mesh = GameObject.Find("cat_paw_mesh");
		mesh = cat_paw_mesh.GetComponent<MeshRenderer>();
		mesh.enabled = true;
		
		cat_anim = paw_main.GetComponent<Animator>();
		cat_anim.enabled = true;
		cat_anim.SetTrigger ("reset");
		Debug.Log ("anim = true");
		
		cat_box_collider = paw_main.GetComponent<BoxCollider>();
		cat_box_collider.enabled = true;
		
		cat_playerSwipe = paw_main.GetComponent<PlayerSwipe>();
		cat_playerSwipe.enabled = true;

		paw_main_animator.SetTrigger ("to_paw");
		current_cat_paw = paw_main;
		toast_changed = true;
		to_main = true;

	}
}
