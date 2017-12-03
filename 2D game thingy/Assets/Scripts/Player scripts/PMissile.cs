using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMissile : MonoBehaviour {

	public float ActivateTime;
	public Transform target;
	public float MoveSpeed = 10;
	
	void Update () {
		if (ActivateTime <= 0 && target == null)
		{
			target = GameObject.FindGameObjectsWithTag("Enemy")[Random.Range(0, GameObject.FindGameObjectsWithTag("Enemy").Length)].transform;
			if (target.name != "Body")
			{
				target = null;
			}
			else
			{
				MoveSpeed *= 2;
			}
		}
		else if (target != null)
		{
			transform.right = target.position - transform.position;
			Debug.DrawLine(transform.position, target.position);
		}
		transform.localPosition += (transform.right * MoveSpeed * Time.deltaTime);
		ActivateTime -= Time.deltaTime;
	}
}
