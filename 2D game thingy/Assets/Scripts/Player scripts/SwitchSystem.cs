using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TP = ShipTemplate; //because at this point I'm just trying everything

public class SwitchSystem : MonoBehaviour
{

    private List<ShipTemplate> Roster = new List<ShipTemplate>();
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

		Camera.main.transform.BroadcastMessage("SetLives", new int[2] { remainingPla, index });
        StartPos = transform.position;
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Roster[index].sprite;
    }

    void Update()
    {
		print(Roster[index]);
		if (Input.GetButtonDown("Ability") && AbilityCharge == 100)
		{
			AbilityActive = true;
			Roster[index].AbilityActive = true;
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
			Roster[index].AbilityActive = false;
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
            index--;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Roster[index].sprite;
			Camera.main.transform.BroadcastMessage("SetLives", new int[2] { remainingPla, index });
		}
        else if (Input.GetButtonDown("SwitchR") && index < remainingPla-1)
        {
            index++;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Roster[index].sprite;
			Camera.main.transform.BroadcastMessage("SetLives", new int[2] { remainingPla, index });
		}
    }

    void EvaluateChildren()
    {
		print("-----------------------Death--------------------------\nremainingPla: "+remainingPla+"\nindex: "+index+ "\n------------------------------------------------------");
		
		if (remainingPla == 1) //That was our last life
		{
			print("Dying lmao");
			Camera.main.transform.BroadcastMessage("SetHealth", index);
			Camera.main.transform.BroadcastMessage("SetLives", new int[2] { index, -1 });
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
            Camera.main.transform.BroadcastMessage("SetLives", new int[2] { remainingPla, index });
        }
        GameObject NewPlayer = Instantiate(Base, transform.position, Quaternion.Euler(0, 0, 0), transform);
        NewPlayer.GetComponent<SpriteRenderer>().sprite = Roster[index].sprite;
		NewPlayer.transform.name = "Player";
		print("New Player spawned");
		foreach (Arrow i in Roster)
		{
			i.Ship = NewPlayer.transform;
		}
	}
}
