using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public int health = 100;
    public bool IsPlayer = false;

	void Start()
	{
		if (IsPlayer)
		{
			Camera.main.transform.BroadcastMessage("SetHealth", 100);
		}
	}

	public void TakeDamage(int amount) //Generic function for taking damage via raycast, essentially bypassing the need to do error checking
	{
		print(transform.name);
		print("Old health: " + health);
		health -= amount;
		print("New health: " + health);
        if (IsPlayer)
        {
            Camera.main.transform.BroadcastMessage("SetHealth", health);
        }
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		print("hit " + hit.transform.name);
		if (hit.transform.tag != transform.tag && hit.transform.tag != "Pickup" && health > 0)
		{
            try
            {
                health -= hit.transform.GetComponent<Bullet>().Damage;
                Destroy(hit.gameObject);
            }
            catch
            {
                health -= 20;
				Destroy(hit.gameObject);
			}
            finally
            {
                if (IsPlayer)
                {
                    Camera.main.transform.BroadcastMessage("SetHealth", health);
                }
                if (health <= 0)
                {
					Destroy(gameObject);
					transform.parent.BroadcastMessage("EvaluateChildren"); //check if all other elements are dead
				}
            }
        }
		else if (hit.transform.tag == "Pickup" && transform.tag == "Player")
		{
			hit.transform.BroadcastMessage("Tag",transform);
		}
	}
}
