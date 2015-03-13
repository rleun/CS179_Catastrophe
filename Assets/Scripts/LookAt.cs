using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
	public Transform target;
	//NavMeshAgent nav;
	// Update is called once per frame
	void Start ()
	{
		//nav = transform.GetComponent<NavMeshAgent> ();
	}
	void Update () 
	{
		//	nav.SetDestination (target.position);
		transform.LookAt (target);
	}
}
