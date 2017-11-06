using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	
	public GameObject projectile;
	public float fireDelay;
	private float delayCounter = 0.0f;
	public Vector3 RelativePos;
	public int Damage = 2;

    public float MoveSpeed = 0;
	
	void Update () {
		if (Input.GetButton("Fire1") && delayCounter<=0)
		{
			GameObject bullet = Instantiate(projectile, transform.position+RelativePos, Quaternion.Euler(0,0,0), transform.parent.parent);
			bullet.GetComponent<Bullet>().Damage = Damage;
			bullet.transform.tag = transform.tag;
			bullet.GetComponent<Bullet>().speed = (MoveSpeed * 2);
			delayCounter = fireDelay;
		}
		else if (delayCounter > 0)
		{
			delayCounter -= Time.deltaTime; //Changed to DeltaTime so the firing speed isn't effected by lag anymore
		}
	}
}
