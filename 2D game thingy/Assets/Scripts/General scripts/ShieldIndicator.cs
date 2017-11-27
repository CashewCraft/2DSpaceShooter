using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldIndicator : MonoBehaviour {
	
	void Update () {
		transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(transform.GetChild(0).GetComponent<SpriteRenderer>().color.r, (float)transform.GetComponent<Damage>().health/255, transform.GetChild(0).GetComponent<SpriteRenderer>().color.b, transform.GetChild(0).GetComponent<SpriteRenderer>().color.a);
	}
}
