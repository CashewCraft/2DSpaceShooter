using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipTemplate
{
	public string Name = "Lettuce";
	public Sprite sprite;
	public Transform Ship;

	public GameObject Bullet;

	public int Damage = 2;
	public float MoveSpeed = 17;

	public float delayCounter;
	public float fireDelay;

	public float DecayFactor = 1;

	public abstract void Fire();
	public abstract void Ability();
	public abstract void AbilityEnd();

	public bool AbilityActive = false;
}

public class Arrow : ShipTemplate
{

	public GameObject missile;

	public Arrow(Transform me)
	{
		Name = "Arrow";

		Ship = me;

		DecayFactor = 20; //Set new variables here to ensure they're overwritten
		delayCounter = 0; //I don't understand the other methods of doing this so
		fireDelay = 0.025f; //this will have to do for now

	ShipTypes sl = GameObject.FindGameObjectsWithTag("Library")[0].GetComponent<ShipTypes>();
		int index = sl.GetIndexFromName(Name);
		sprite = sl.Sprites[index];
		Bullet = sl.Bullets[index];
		missile = sl.Secondary[index];
    }

	//Overrides for actions
	public override void Fire()
	{
        if (delayCounter <= 0)
		{
			GameObject bullet = MonoBehaviour.Instantiate((AbilityActive) ? missile : Bullet, Ship.position, Quaternion.Euler(0, 0, (AbilityActive) ? 90 : 0), Ship.parent.parent);
			if (AbilityActive)
			{
				delayCounter = fireDelay * 8;
			}
			else
			{
				bullet.GetComponent<Bullet>().Damage = Damage;
				bullet.GetComponent<Bullet>().speed = (MoveSpeed * 2);
				delayCounter = fireDelay;
			}
			bullet.transform.tag = Ship.tag;
		}
		else
		{
			delayCounter -= Time.deltaTime;
		}
	}

	public override void Ability() { AbilityActive = true; }
	public override void AbilityEnd() { AbilityActive = false; }
}

public class Escort : ShipTemplate
{

	public GameObject shield;
	public GameObject shieldRef;

	public Escort(Transform me)
	{
		Name = "Escort";

		Ship = me;

		DecayFactor = 5; //Set new variables here to ensure they're overwritten
		delayCounter = 0; //I don't understand the other methods of doing this so
		fireDelay = 0.1f; //this will have to do for now

		ShipTypes sl = GameObject.FindGameObjectsWithTag("Library")[0].GetComponent<ShipTypes>();
		int index = sl.GetIndexFromName(Name);
		sprite = sl.Sprites[index];
		Bullet = sl.Bullets[index];
		shield = sl.Secondary[index];
	}

	//Overrides for actions
	public override void Fire()
	{
		if (delayCounter <= 0)
		{
			GameObject bullet = MonoBehaviour.Instantiate(Bullet, Ship.position, Quaternion.Euler(0, 0, 0), Ship.parent.parent);
			bullet.GetComponent<Bullet>().Damage = Damage;
			bullet.GetComponent<Bullet>().speed = (MoveSpeed * 2);
			delayCounter = fireDelay;
			bullet.transform.tag = Ship.tag;
		}
		else
		{
			delayCounter -= Time.deltaTime;
		}
	}

	public override void Ability()
	{
		if (shieldRef == null)
		{
			shieldRef = MonoBehaviour.Instantiate(shield, Ship.position, Quaternion.Euler(0, 0, 0), Ship);
		}
	}

	public override void AbilityEnd()
	{
		if (shieldRef != null)
		{
			MonoBehaviour.Destroy(shieldRef);
		}
	}
}