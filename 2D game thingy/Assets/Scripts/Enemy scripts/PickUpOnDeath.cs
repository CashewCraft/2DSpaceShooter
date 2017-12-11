using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOnDeath : MonoBehaviour {

	public float PickupChance; //chance to drop, as a percentage
	public GameObject[] PickupList; //array of pickup prefabs
	private int Children;

	public float points;

	public int MaxNoPickups = 1;

	void Start()
	{
		Children = transform.childCount;
	}

	void EvaluateChildren() //updates how many children are alive
	{
		Children--;
		if (Children == 1) //1 because we're excluding the bullet holder
		{
            if (Random.Range(1,100) <= PickupChance)
			{
				Camera.main.transform.BroadcastMessage("AddCharge", points*2);
				DropPickup();
			}
			Camera.main.transform.BroadcastMessage("AddCharge", points);
		}
	}

	void DropPickup()
	{
		for (int i = 0; i < MaxNoPickups; i++)
		{
			print("Generating drop #" + i + " with a chance of " + PickupChance + "%");
			if ((i > 0 && Random.Range(1, 100) <= PickupChance) || i == 0)
			{
				PickupChance *= (PickupChance / 100);
				Instantiate(PickupList[Random.Range(0, PickupList.Length)], (Vector2)transform.position + (Random.insideUnitCircle * 3), new Quaternion(0, 0, 0, 0), null);
			}
		}
	}
}
