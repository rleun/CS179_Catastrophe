using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

	public ParticleSystem muzzleFlash;
	Animator anim;
	public GameObject impactPrefab;
	GameObject enemy;
	VacuumHealth vacHealth;
	
	//Robot
	GameObject EnemyRobot;
	EnemyHealth RobotHealth;

	//Helicopter
	GameObject EnemyHelicopter;
	EnemyHealth HelicopterHealth;


	float timer = .5f;
	
	GameObject[] impacts;
	int currentImpact = 0;
	int maxImpacts = 1;
	public GameObject shootingToast;
	public float shootForce = 10;
	public float shootingTimeDelay;
	float shootingTimer;
	float changeTimer;
	public float changeTimerDelay;
	public int ammoAmount;
	PlayerPaw playerpaw;
	int ammo;

	public Text ToastAmmoText;

	public bool changeToMain;
	
	bool shooting = false;
	
	// Use this for initialization
	void Start () {
		changeTimer = changeTimerDelay;
		shootingTimer = shootingTimeDelay;
		impacts = new GameObject[maxImpacts];
		for(int i = 0; i < maxImpacts; i++)
		{
			impacts[i] = (GameObject)Instantiate(impactPrefab);
		}

		anim = GetComponentInChildren<Animator> ();

		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		//Change later to encompase all enemies
		vacHealth = enemy.GetComponent <VacuumHealth> ();

		//Set this for robot
		EnemyRobot = GameObject.FindGameObjectWithTag ("Robot");
		RobotHealth = EnemyRobot.GetComponent<EnemyHealth> ();

		//Set this for Helicopter
		EnemyHelicopter = GameObject.FindGameObjectWithTag ("Helicopter");
		HelicopterHealth = EnemyHelicopter.GetComponent<EnemyHealth> ();

		ammo = ammoAmount;
		changeToMain = false;

		playerpaw = GetComponent<PlayerPaw> ();

		//ToastAmmoText = GameObject.FindGameObjectWithTag ("ToastAmmoText");
		ToastAmmoText.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		//if(playerpaw.is_toast)
		if(true)
		{
			ToastAmmoText.text = "Toast ammo: " + ammo;
		}
		else
		{
			ToastAmmoText.text = "";
		}

		if(Input.GetButtonDown ("Fire1") && (shootingTimer <= 0) && (ammo > 0))
		{
			muzzleFlash.Play();
			//anim.SetTrigger("Fire");
			shooting = true;
			shootingTimer = shootingTimeDelay;
			ammo--;
		}
		shootingTimer -= Time.deltaTime;

		if(ammo <= 0)
		{
			if(changeTimer <= 0)
			{
				ammo = ammoAmount;
				changeToMain = true;
				changeTimer = changeTimerDelay;

			}
			else
			{
				changeTimer -= Time.deltaTime;
			}
		}
		
	}

	void CreateProjectile()
	{
		//Shoot Projectile
		GameObject projectile = Instantiate(shootingToast,transform.position, transform.rotation) as GameObject;
		projectile.AddComponent<Rigidbody> ();
		projectile.rigidbody.AddForce(transform.forward*5000);
		Destroy (projectile, 1f);
//		float projectileTimer = .5f;
//		while(projectileTimer > 0)
//		{
//			timer -= Time.deltaTime;
//		}


	}
	
	void FixedUpdate()
	{
		if(shooting)
		{
			timer -= Time.deltaTime;



			//Impact
			if(timer <= 0)
			{
				CreateProjectile();


				shooting = false;
				
				RaycastHit hit;


				if(Physics.Raycast(transform.position, transform.forward, out hit, 50f))
				{
					//Instantiate(shootingToast, hit.point, transform.rotation);
					//Destroy(shootingToast);
					Transform clone;
//					clone = Instantiate(shootingToast, transform.position, transform.position);
//					clone.rigidbody.AddForce(clone.transform.forward*shootForce);



					if(hit.transform.tag == "Enemy")
	//					Destroy (hit.transform.gameObject);
					{
						vacHealth.TakeDamage(1);
					}

					if(hit.transform.tag == "Robot")
					{
						RobotHealth.TakeDamage(1);
					}

					if(hit.transform.tag == "Helicopter")
					{
						HelicopterHealth.TakeDamage(1);
					}


					Debug.Log("hit something: " + hit.transform.tag);
					impacts[currentImpact].transform.position = hit.point;
					impacts[currentImpact].GetComponent<ParticleSystem>().Play();


					if(++currentImpact >= maxImpacts)
					{
						currentImpact = 0;
					}

					//Destroy(projectile);
				}

				timer = .5f;
			}
		}
	}
}