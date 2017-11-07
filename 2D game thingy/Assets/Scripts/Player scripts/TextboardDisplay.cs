using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextboardDisplay : MonoBehaviour {

    public Text text;
	
	// Update is called once per frame
	void Update () {
        text.text = "Health: " + transform.GetComponent<Damage>().health;
	}
}
