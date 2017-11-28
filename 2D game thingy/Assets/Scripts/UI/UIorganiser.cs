using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIorganiser : MonoBehaviour {
	
	void Start () {
		transform.GetChild(0).localScale = new Vector3(1, 0.3f, 1);
		transform.GetChild(1).localScale = new Vector3(1, 0.3f, 1);
		transform.GetChild(2).localScale = new Vector3(1, 0.4f, 1);

		transform.GetChild(0).transform.localPosition = new Vector3(0, 0.35f, 0);
		transform.GetChild(1).transform.localPosition = new Vector3(0, 0.05f, 0);
		transform.GetChild(2).transform.localPosition = new Vector3(0, -0.3f, 0);
	}
}
