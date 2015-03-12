using UnityEngine;
using System.Collections;

public class RobotAnimatorScript : MonoBehaviour {

	EnemyAI enemyAIScript;
	Animator anim;

	// Use this for initialization
	void Start () {
		enemyAIScript = GetComponent<EnemyAI> ();
		anim = GetComponent<Animator> ();

		anim.SetBool("Attack",false);
		anim.SetBool("Jump",true);
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyAIScript.currentHealth > 0) 
		{
			if(enemyAIScript.CurrentDistance < 8)
			{
				anim.SetBool("Attack",true);
				anim.SetBool("Jump",false);
			}
			else
			{
				anim.SetBool("Attack",false);
				anim.SetBool("Jump",true);
			}
		}
		else
		{
			anim.SetTrigger("Dead");
		}

	}
}
