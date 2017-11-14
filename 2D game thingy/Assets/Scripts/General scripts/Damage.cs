using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	public int health = 100;

	void OnTriggerEnter2D(Collider2D hit)
	{
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
		else if (hit.transform.tag == "Pickup")
		{
			print("ayy");
			hit.transform.BroadcastMessage("Tag",transform);
		}
	}
}
