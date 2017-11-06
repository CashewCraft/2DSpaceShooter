using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

	public Vector3 Centre;
	public float Range;

	public float Speed;
	public float TurnSpeed;

	public bool? LR;
	
	void Update () {

		Vector3 P = transform.position;
		Vector3 Q = transform.up;

		//float A = P.y-Q.y;
		//float B = Q.x-P.x;
		//float C = (P.x-Q.y)+(Q.x-P.y);

		//print(A+"x + "+B+"y + "+C+" = 0");
		//print(LR);

		//print("I am " + Vector3.Distance(transform.position, Centre) + " away from the centre");

		if (Vector3.Distance(transform.position, Centre) < Range)
		{
			//print("I am "+ Vector3.Distance(transform.position, Centre)+" away from the centre, which is within the range.");
			switch (Random.Range(1, 10))
			{
				case 1:
					transform.Rotate(new Vector3(0, 0, TurnSpeed * Time.deltaTime));
					break;
				case 2:
					transform.Rotate(new Vector3(0, 0, -TurnSpeed * Time.deltaTime));
					break;
			}
			transform.Translate((transform.up*Speed)*Time.deltaTime, Space.Self);
		}
	}
}
