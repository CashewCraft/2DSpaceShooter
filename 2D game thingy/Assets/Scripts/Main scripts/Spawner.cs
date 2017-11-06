using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public bool SpawnA;
	public float ADelayMin;
	private float ADelayCounter = 0;
	public float ADelayMax;

	public bool SpawnB;

	public bool SpawnD;
	
	public GameObject TypeA;
	
	void Update () {
		if (SpawnA && ADelayCounter <= 0)
		{
			Instantiate(TypeA, new Vector3(999,999,999), Quaternion.Euler(0, 0, 0));
			ADelayCounter = Random.Range(ADelayMin, ADelayMax);
		}
		ADelayCounter -= Time.deltaTime;
	}
}
