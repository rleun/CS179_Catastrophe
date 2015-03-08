using UnityEngine;
using UnityEngine.UI;

public class VacuumHealth : MonoBehaviour
{

    public int startingHealth;
    public int currentHealth;
	public AudioClip aliveClip;
    public AudioClip deathClip;
//	public GameObject victoryText;

    Animator anim;
    AudioSource vacAudio;
    SphereCollider sphereCollider;
	ParticleSystem pSystem;
    bool isDead;
	bool firstAudio = true;
	private float startTime;
	private float elapsedTime;
	GameObject cat_paw_main;


	//Boss Health UI
	public GameObject EnemyHealthObject;
	public Text DisplayName;
	public string EnemyName;
	public Slider healthSlider;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
		currentHealth = startingHealth;
        vacAudio = GetComponent <AudioSource> ();
		sphereCollider = GetComponent <SphereCollider> ();
		pSystem = GetComponent <ParticleSystem> ();
		cat_paw_main = GameObject.Find ("Main Camera");
		vacAudio.clip = aliveClip;
		startTime = Time.time;

		//Set boss health UI
		DisplayName.text = EnemyName;
		healthSlider.value = currentHealth;

    }


    void Update ()
    {
		healthSlider.value = currentHealth;

		elapsedTime = Time.time;
		vacAudio.volume = 1f;
		if (!isDead && (elapsedTime - startTime > 44f) | firstAudio ) 
		{
			firstAudio = false;
			vacAudio.loop = true;
			vacAudio.Play ();
			startTime = elapsedTime;
		}

    }


    public void TakeDamage (int amount)
    {
        if(isDead)
		{
            return;
		}
		//Audio source
        //vacAudio.Play ();

		PlayerPaw currentPaw = cat_paw_main.GetComponent<PlayerPaw> ();
		if(currentPaw.is_main)
		{
			//Get Particle System for onHit
			GameObject vacuumParticle = GameObject.Find ("VacuumHitParticle");
			pSystem = vacuumParticle.GetComponent<ParticleSystem> ();
			pSystem.Play ();
		}



        currentHealth -= amount;
		Debug.Log ("Vacuum takes " + amount + " damage. HP left: " + currentHealth);
         
        if(currentHealth <= 0)
        {
			Debug.Log("Vacuum Dead");
            Die ();
        }
    }


    void Die ()
    {
        isDead = true;

		sphereCollider.isTrigger = true;

       // anim.SetTrigger ("gameWin");
		

        vacAudio.clip = deathClip;
		vacAudio.volume = 0.00005f;
		vacAudio.loop = false;
        vacAudio.Play ();
		//Show victory text
//		victoryText.SetActive(true);
    }


}
