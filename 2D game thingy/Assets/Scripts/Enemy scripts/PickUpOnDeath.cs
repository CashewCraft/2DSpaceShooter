using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpOnDeath : MonoBehaviour {

	public int PickupChance; //chance to drop, as a percentage
	public GameObject[] PickupList; //array of pickup prefabs
	private int Children;

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
                DropPickup();
			}
		}
	}

	void DropPickup()
	{
		Instantiate(PickupList[Random.Range(0, PickupList.Length)], transform.position, new Quaternion(0,0,0,0), null);
	}
}
