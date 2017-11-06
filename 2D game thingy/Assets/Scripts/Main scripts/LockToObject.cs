using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToObject : MonoBehaviour {

	//General script to keep something constantly looking at an object
	public Transform Target; 
	
	void Update () {
		transform.up = (Target.position - transform.position);
	}
}
