using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBoomReset : MonoBehaviour {

	public float life = 1;

	void Update()
	{
		life += 0.05f;
		transform.localScale = new Vector3(life, life, 1);
		transform.localPosition = new Vector3(0, 0, 0);
		transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (255f - (life * 100f)) / 255);
		if (life * 100 >= 255) { life = 1; }
	}
}
