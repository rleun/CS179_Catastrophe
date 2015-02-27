using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 10f;

	Vector3 offset;

	void Start()
	{
		offset = transform.position - target.position;
	}

	void FixedUpdate()
	{
		Vector3 targetLightPosition = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetLightPosition, smoothing);
	}
}
