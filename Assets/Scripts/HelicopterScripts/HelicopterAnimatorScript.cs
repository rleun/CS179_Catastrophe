using UnityEngine;
using System.Collections;

public class HelicopterAnimatorScript : MonoBehaviour {

	EnemyAI EnemyAIScript;
	Animator anim;

	// Use this for initialization
	void Start () {
		EnemyAIScript = GetComponent<EnemyAI> ();
		anim = GetComponent<Animator> ();

		anim.SetBool ("Take-Off", false);

	}
	
	// Update is called once per frame
	void Update () {

		if(EnemyAIScript.currentHealth > 0)
		{
			if(EnemyAIScript.PlayerWithInRange)
			{
				anim.SetBool ("Take-Off", true);
			}
		}
		else
		{
			anim.SetTrigger("Death");
		}
	}
}
