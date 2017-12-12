using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPoints : MonoBehaviour {

	void Start () {
		Vector3 TL = Camera.main.WorldToScreenPoint(transform.position-(transform.localScale/2));
		Vector3 BR = Camera.main.WorldToScreenPoint(transform.position + (transform.localScale / 2));

		print("Point TL: " + TL);
		print("Point BR: " + BR);
	}
}
