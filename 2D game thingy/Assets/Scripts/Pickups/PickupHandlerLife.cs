using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandlerLife : MonoBehaviour {

	public float speed = 10;
	private bool Active = false;
	public float lifeSpan = 0;
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
			transform.parent = hit;
			Destroy(transform.GetComponent<SpriteRenderer>()); //Woo, I'm a ghost
			Destroy(transform.GetChild(0).gameObject);
			Active = true;
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
	}

	void OnPowerUpDead()
	{
		//Reverse of above
		if (transform.parent.parent.GetComponent<SwitchSystem>().remainingPla < 6)
		{
			transform.parent.parent.GetComponent<SwitchSystem>().remainingPla += 1;
			transform.parent.parent.GetComponent<SwitchSystem>().Roster.Add((Random.Range(0,2)==1)? (ShipTemplate)new Arrow(transform.parent.parent) : (ShipTemplate)new Escort(transform.parent.parent));
			Camera.main.transform.BroadcastMessage("SetLives", transform.parent.parent.GetComponent<SwitchSystem>().Pack());
        }
		else
		{
			transform.parent.GetComponent<Damage>().health = 110;
			Camera.main.transform.BroadcastMessage("SetHealth", transform.parent.GetComponent<Damage>().health);
		}
	}
}
