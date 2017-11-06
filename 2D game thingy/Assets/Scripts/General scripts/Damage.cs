using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public int health = 100;

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.transform.tag != transform.tag && hit.transform.tag != "Pickup")
		{
			try
			{
				health -= hit.transform.GetComponent<Bullet>().Damage;
				Destroy(hit.gameObject); //needs to be here so we don't kill the player
			}
			catch //catch for cases in which it's not a bullet (i.e. it's an enemy or debris)
			{
				health -= 20; //flat value for now, may change
			}
			finally
			{
				if (health <= 0)
				{
					transform.parent.BroadcastMessage("EvaluateChildren"); //Check if the last child has died
					Destroy(gameObject);
				}
			}
			
        }
		
	}
}
