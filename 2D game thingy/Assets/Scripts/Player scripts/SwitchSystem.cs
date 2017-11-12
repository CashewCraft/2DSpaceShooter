using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSystem : MonoBehaviour
{

    public Sprite[] Roster = new Sprite[6];
    public GameObject Base;
    private int index = 0;
    public int remainingPla = 5;
    private Vector3 StartPos;

    void Start()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        if (Input.GetButtonDown("SwitchL") && index > 0)
        {
            index--;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Roster[index];
        }
        else if (Input.GetButtonDown("SwitchR") && index < remainingPla)
        {
            index++;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Roster[index];
        }
    }

    void EvaluateChildren()
    {
		if (index == remainingPla)
		{
			remainingPla--;
			Roster[index] = null;
			index--;
		}
		else if (remainingPla == 0) //That was our last life
		{
			Destroy(gameObject);
			//death stuff
		}
		else
		{
			Roster[index] = null;
			remainingPla--;
			for (int i = 1; i < Roster.Length; i++)
			{
				if (Roster[i - 1] == null)
				{
					Roster[i - 1] = Roster[i];
					Roster[i] = null;
				}
			}
		}
        GameObject NewPlayer = Instantiate(Base, transform.position, Quaternion.Euler(0, 0, 0), transform);
        NewPlayer.GetComponent<SpriteRenderer>().sprite = Roster[index];
    }
}
