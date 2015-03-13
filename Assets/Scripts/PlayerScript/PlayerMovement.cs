using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;
	float time = 0;

	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame, reset speed to normal after 3 seconds
	void Update ()
	{
		time += Time.deltaTime;
		if(speed < 6f && time > 3f)
		{
			speed = 6f;
			time = 0;
		}
		else if(speed > 6f && time > 10f)
		{
			speed = 5f;
			time = 0;
		}
	}
	//speed modifier function
	public void TempSpeed(float temp_speed)
	{
		time = 0;
		speed = temp_speed;
	}
}
