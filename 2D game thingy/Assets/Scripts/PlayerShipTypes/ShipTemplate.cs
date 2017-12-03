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

	public float DecayFactor = 1;

	public abstract void Fire();
	public abstract void Ability();

	public bool AbilityActive = false;
}

public class Arrow : ShipTemplate
{
	new public string Name = "Arrow";

	public GameObject missile;

	public float delayCounter = 0;
	public float fireDelay = 0.025f;

	public Arrow(Transform me)
	{
		Ship = me;
		DecayFactor = 20;
		ShipTypes sl = GameObject.FindGameObjectsWithTag("Library")[0].GetComponent<ShipTypes>();
		int index = sl.GetIndexFromName(Name);
		sprite = sl.Sprites[index];
		Bullet = sl.Bullets[index];
		missile = sl.Secondary[index];
    }

	//Overrides for actions
	public override void Fire()
	{
		MonoBehaviour.print("ayy");
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
			MonoBehaviour.print("lmao");
			delayCounter -= Time.deltaTime;
		}
	}

	public override void Ability() {}
}