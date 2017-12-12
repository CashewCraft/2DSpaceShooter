using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public int health = 100;
    public bool IsPlayer = false;
	
	public int blip = 0;

	void Start()
	{

		if (IsPlayer)
		{
			Camera.main.transform.BroadcastMessage("SetHealth", 100);
		}
	}

	public void TakeDamage(int amount) //Generic function for taking damage via raycast, essentially bypassing the need to do error checking
	{
		health -= amount;
        if (IsPlayer)
        {
            Camera.main.transform.BroadcastMessage("SetHealth", health);
        }
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
        if (hit.transform.tag != transform.tag && hit.transform.tag != "Pickup" && health > 0)
        {
            if (blip == 0)
            {
                try
                {
                    transform.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                }
                catch
                {
                    foreach (SpriteRenderer i in transform.GetComponentsInChildren<SpriteRenderer>())
                    {
                        i.color = new Color(0, 0, 0, 255);
                    }
                }
                blip = 2;
            }

            try
            {
                health -= hit.transform.GetComponent<Bullet>().Damage;
                Destroy(hit.gameObject);
            }
            catch
            {
                if (hit.tag != transform.tag)
                {
                    health -= 20;
                }
            }
            if (IsPlayer)
            {
                Camera.main.transform.BroadcastMessage("SetHealth", health);
            }
        }
		else if (hit.transform.tag == "Pickup" && transform.tag == "Player")
		{
			hit.transform.BroadcastMessage("Tag",transform);
		}


        if (health <= 0)
        {
            Destroy(gameObject);
            transform.parent.BroadcastMessage("EvaluateChildren"); //check if all other elements are dead
        }
    }

	void Update()
	{
		if (blip > 0)
		{
			blip--;
			if (blip == 0)
			{
				try
				{
					transform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
				}
				catch
				{
					foreach (SpriteRenderer i in transform.GetComponentsInChildren<SpriteRenderer>())
					{
						i.color = new Color(255, 255, 255, 255);
					}

				}
			}
		}
	}
}
