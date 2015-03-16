using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {

	static bool created = false;
	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		if(!created)
		{
			DontDestroyOnLoad (gameObject);
			if(!gameObject.GetComponent<AudioSource>().isPlaying)
			{
				gameObject.GetComponent<AudioSource>().Play();
			}
			created = true;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
