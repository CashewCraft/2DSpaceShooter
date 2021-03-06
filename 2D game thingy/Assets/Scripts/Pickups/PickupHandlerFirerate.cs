﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandlerFirerate : MonoBehaviour {

	public float speed = 10;
	private bool Active = false;
	public float lifeSpan = 20;
	public int index;

	void Update () {
		if (!Active)
		{
			transform.localPosition -= (transform.up * speed * Time.deltaTime);
		}
		else
		{
			if (lifeSpan <= 0)
			{
				OnPowerUpDead();
				Destroy(gameObject);
			}
			else
			{
				lifeSpan -= Time.deltaTime;
			}
		}
	}

	void Tag(Transform hit)
	{
		if (hit.name == "Player")
		{
			transform.parent = hit.transform;
			Destroy(transform.GetComponent<SpriteRenderer>()); //Woo, I'm a ghost
			Destroy(transform.GetChild(0).gameObject);
			Active = true;
			index = transform.parent.parent.GetComponent<SwitchSystem>().index;
			OnPowerUpActive();
		}
	}

	void OnBecameInvisible()
	{
		if (!Active)
		{
			Destroy(gameObject);
		}
	}

	void OnPowerUpActive()
	{
		//Powerup stuff
		transform.parent.parent.GetComponent<SwitchSystem>().Roster[index].fireDelay /= 2;
		transform.parent.parent.GetComponent<SwitchSystem>().Roster[index].Damage = Mathf.Max(1, transform.parent.parent.GetComponent<SwitchSystem>().Roster[index].Damage / 2);
		//Adjust damage because firerate is ment to be ability to saturate screen with bullets, not DPS
	}

	void OnPowerUpDead()
	{
		//Reverse of above
		transform.parent.parent.GetComponent<SwitchSystem>().Roster[index].fireDelay *= 2;
		transform.parent.parent.GetComponent<SwitchSystem>().Roster[index].Damage *= 2;
	}
}
