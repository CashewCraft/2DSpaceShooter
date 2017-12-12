using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

	float Score = 0;

	void AddCharge(float xp)
	{
		Score += xp;
		transform.GetComponent<TextMesh>().text = "Score:  " + Score.ToString();
	}
}
