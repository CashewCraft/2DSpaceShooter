using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {

	public GameObject projectile;
	public float fireDelay;
	public float delayCounter = 3.0f;
	public int Damage = 2;

	public float MoveSpeed = 0;

	void Start()
	{
		delayCounter = fireDelay + Random.Range(-0.5f, 1);
	}

	void Update()
	{
		if (delayCounter <= 0)
		{
			GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(-transform.localRotation.eulerAngles), transform.parent.Find("BulletHolder"));
			bullet.GetComponent<Bullet>().Damage = Damage;
			bullet.transform.tag = transform.tag;
			bullet.GetComponent<Bullet>().speed = (MoveSpeed * 2);
			delayCounter = fireDelay + Random.Range(-0.5f,1);
		}
		else if (delayCounter > 0)
		{
			delayCounter -= Time.deltaTime; //Changed to DeltaTime so the firing speed isn't effected by lag anymore
		}
	}
}
