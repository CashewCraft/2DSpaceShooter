using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeUI : MonoBehaviour {

	private float AbilityCharge = 0;
	private bool AbilityActive = false;

	public void SetCharge(float val)
	{
        AbilityCharge = val;
		transform.GetChild(0).localScale = new Vector3(1, AbilityCharge / 100, 1);
		transform.GetChild(0).localPosition = new Vector3(0, -(1 - (AbilityCharge / 100)) / 2, -1);
	}

	public void AddCharge(float val)
	{
		AbilityCharge = Mathf.Min(AbilityCharge+val,100);
		SetCharge(AbilityCharge);
	}

    public float GetCharge()
	{
		return AbilityCharge;
	}

	public void SetActive(bool val)
	{
		AbilityActive = val;
	}

	public bool GetActive()
	{
		return AbilityActive;
	}
}
