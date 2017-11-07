using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public bool SpawnA;
	public float ADelayMin;
	private float ADelayCounter = 0;
	public float ADelayMax;

	public bool SpawnB;

	public bool SpawnC;
	public float CDelayMin;
	private float CDelayCounter = 0;
	public float CDelayMax;

	public bool SpawnD;
	
	public GameObject TypeA;
	public GameObject TypeC;

	void Update () {
		if (SpawnA && ADelayCounter <= 0)
		{
			Instantiate(TypeA, new Vector3(999,999,999), Quaternion.Euler(0, 0, 0));
			ADelayCounter = Random.Range(ADelayMin, ADelayMax);
		}
		ADelayCounter -= Time.deltaTime;
		if (SpawnC && CDelayCounter <= 0)
		{
			Instantiate(TypeC, new Vector3(999, 999, 999), Quaternion.Euler(0, 0, 0));
			CDelayCounter = Random.Range(CDelayMin, CDelayMax);
		}
		CDelayCounter -= Time.deltaTime;
	}
}
