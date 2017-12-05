using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TP = ShipTemplate; //because at this point I'm just trying everything

public class StoreItem
{
	public Sprite[] spriteLis;
	public int remain;
	public int index;
}

public class SwitchSystem : MonoBehaviour
{

    public List<ShipTemplate> Roster = new List<ShipTemplate>();
	//Classes inheriting from the parent can be stored here, so we can have different firing methods stored in this list

    public GameObject Base;
    public int index = 0;
    public int remainingPla = 3;
    private Vector3 StartPos;

	public float AbilityCharge = 0;
	private bool AbilityActive = false;

	public GameObject bullet;
	public GameObject missile;

    void Start()
    {
        Roster.Add(new Arrow(transform));
		Roster.Add(new Escort(transform));

		Camera.main.transform.BroadcastMessage("SetLives", Pack());
        StartPos = transform.position;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Roster[index].sprite;
    }

    void Update()
    {
		if (Input.GetButtonDown("Ability") && AbilityCharge == 100)
		{
			AbilityActive = true;
        }
		if (AbilityActive && AbilityCharge > 0)
		{
			AbilityCharge = Mathf.Max(AbilityCharge - Time.deltaTime*Roster[index].DecayFactor, 0);
			Camera.main.transform.BroadcastMessage("SetCharge", AbilityCharge);
			Roster[index].Ability();
		}
		if (AbilityCharge == 0)
		{
			AbilityActive = false;
			Roster[index].AbilityEnd();
        }
		if (!AbilityActive && AbilityCharge != 100)
		{
			AbilityCharge = Mathf.Min(100, AbilityCharge + Time.deltaTime);
			Camera.main.transform.BroadcastMessage("SetCharge", AbilityCharge);
		}

		if (Input.GetButton("Fire1"))
		{
            Roster[index].Fire();
		}

		if (Input.GetButtonDown("SwitchL") && index > 0)
        {
			Roster[index].AbilityEnd();

			index--;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Roster[index].sprite;
			Camera.main.transform.BroadcastMessage("SetLives", Pack());
        }
        else if (Input.GetButtonDown("SwitchR") && index < remainingPla-1)
        {
			Roster[index].AbilityEnd();

			index++;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Roster[index].sprite;
			Camera.main.transform.BroadcastMessage("SetLives", Pack());
        }
    }

    void EvaluateChildren()
    {
		print("-----------------------Death--------------------------\nremainingPla: "+remainingPla+"\nindex: "+index+ "\n------------------------------------------------------");
		
		if (remainingPla == 1) //That was our last life
		{
			print("Dying lmao");
			Camera.main.transform.BroadcastMessage("SetHealth", index);
			Camera.main.transform.BroadcastMessage("SetLives", Pack());
			//death stuff
			Destroy(gameObject);
			return; //Script would otherwise run and spawn a new player before instantly deleting it, as destroy is run only at the start of the next frame.
		}
		else
		{
			Roster[index] = null;
			remainingPla--;
			for (int i = 1; i < Roster.Count; i++)
			{
				if (Roster[i - 1] == null)
				{
					Roster[i - 1] = Roster[i];
					Roster[i] = null;
				}
			}
			if (Roster[index] == null)
			{
				index--;
			}
            Camera.main.transform.BroadcastMessage("SetLives", Pack() );
        }
        GameObject NewPlayer = Instantiate(Base, transform.position, Quaternion.Euler(0, 0, 0), transform);
        NewPlayer.GetComponent<SpriteRenderer>().sprite = Roster[index].sprite;
		NewPlayer.transform.name = "Player";
		print("New Player spawned");
		foreach (ShipTemplate i in Roster)
		{
			i.Ship = NewPlayer.transform;
		}
	}

	public StoreItem Pack()
	{
		StoreItem Comp = new StoreItem();
		Sprite[] SpLis = new Sprite[6];
		for (int i = 0; i < 6; i++)
		{
			try
			{
				SpLis[i] = Roster[i].sprite;
			}
			catch
			{
				SpLis[i] = null;
			}
		}
		Comp.spriteLis = SpLis;
		Comp.remain = remainingPla;
		Comp.index = index;
		return Comp;
	}
}
