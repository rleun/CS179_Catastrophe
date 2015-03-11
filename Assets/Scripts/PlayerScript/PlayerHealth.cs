using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public int startingHealth = 9;
	public int currentHealth;
	public Slider healthSlider;
	public PlayerLife playerLife;
	//	public Image damageImage;
	//	public AudioClip deathClip;
	//	public float flashSpeed = 5f; 
	//flash speed of the damage image
	//	public Color flashColor = new Color(1f,0f,0f,0.1f);
	public Image damageFlash;
	public float flashSpeed = 5f; 
	//flash speed of the damage image
	public Color flashColor = new Color(1f,0f,0f,0.1f);
	
	CharacterController characterControllerScript;
	MouseLook mouseLookScript;
	PlayerController playerMovement;
	bool isDead;
	bool playerDamaged;
	Rigidbody rigidbody;

	int x = 1;

	public int Lives;
	public Text LifeLabel;
	public GameObject gameoverText;

	public Animator anim;
	
	// Use this for initialization
	void Start () {
		playerMovement = GetComponent <PlayerController> ();
		anim = GetComponent <Animator> ();
		currentHealth = startingHealth;
		LifeLabel.text = "Life Left: " + startingHealth;
		rigidbody = GetComponent<Rigidbody> ();
	}

	void OnParticleCollision(GameObject other)
	{
		if(other)
		{

			TakeDamage(1);
			Debug.Log (other.name);
		}

	}

	// Update is called once per frame
	void Update () {
		
		/*if (playerDamaged) {
			damageImage.color = flashColor;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		playerDamaged = false;
		*/
		characterControllerScript = GetComponent <CharacterController> ();
		
		
		if (playerDamaged) {
			damageFlash.color = flashColor;
		}
		else
		{
			damageFlash.color = Color.Lerp (damageFlash.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		playerDamaged = false;
		LifeLabel.text = "Life Left: " + currentHealth;
		healthSlider.value = currentHealth;



	}
	
	
	public void TakeDamage (int amount)
	{
		playerDamaged = true;
		currentHealth = currentHealth - amount;
		Debug.Log ("Cat takes " + amount + " damage. HP left: " + currentHealth);
		//LifeLabel.text = "Life Left: " + currentHealth;
		//healthSlider.value = currentHealth;
		if (currentHealth <= 0 && !isDead) {
			Die();		
			Debug.Log("Cat dead");
			
			
			
			
			
		}
	}
	
	public void Die()
	{
		isDead = true;
		characterControllerScript.enabled = false;
		//mouseLookScript.enabled = false;
//		gameoverText.SetActive(true);
		//playerMovement.enabled = false;
		
	}
}
