using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public Transform Player;

	void Update ()
    {
		if (Vector3.Distance(Player.position, transform.position) < 3.75f)
        {
            EvaluateChildren();
        }
	}

    void EvaluateChildren()
    {
        print("Boom");
		Destroy(gameObject);
    }
}
