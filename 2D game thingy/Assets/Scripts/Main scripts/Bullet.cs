using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public int Damage = 2;

	void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 6.0f, (1 << LayerMask.NameToLayer(transform.tag)),-Mathf.Infinity, Mathf.Infinity);
		if (hit.collider != null) //Do this raycast so we don't get screwed over by bullets passing "through" an enemy
		{
			transform.position = hit.transform.position;
		}
		else
		{
			transform.localPosition += (transform.up * speed * Time.deltaTime);
		}
	}

	void OnBecameInvisible() //Neat little function that fires the frame the objects exit the camera's FOV, making cleanup easier
	{
		//You spent ~3 hours trying to fix this. THE EDITOR VIEW COUNTS AS A CAMERA TOO #EditorCamerasMatter
		Destroy(gameObject);
	}
}
