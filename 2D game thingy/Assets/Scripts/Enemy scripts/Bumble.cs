using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumble : MonoBehaviour {

	// Script to give enemy fighters ambient movement within their formation

	public float Magnitude = 1; //determines how large the radius of the circle representing their range is
	private Vector3 StartPos; //starting position of the enemy relative to it's parent

	private Vector3 target;

	void Start()
	{
		StartPos = transform.localPosition;
		target = StartPos;
	}

	void Update () {
		if (transform.position == target)
        {
			target = (Vector2)StartPos + (Random.insideUnitCircle * Magnitude);
		}
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime*Magnitude*2);
	}
}
