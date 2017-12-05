using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public Transform Player;

    void Start()
    {
        Player = GameObject.Find("ChaseHead").transform.GetChild(0).GetChild(1);
    }

	void Update ()
    {
		if (Vector3.Distance(Player.position, transform.position) < 1.75f)
        {
			Player.GetChild(0).GetComponent<Damage>().TakeDamage(20);
			BroadcastMessage("EvaluateChildren");
            Destroy(transform.GetChild(0));
		}
	}

	void OnBecameInvisible()
	{
		//#EditorCamerasMatter
		Destroy(gameObject);
	}
}
