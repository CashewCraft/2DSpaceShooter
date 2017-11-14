using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public bool SpawnA;
	public float ADelayMin;
	private float ADelayCounter = 0;
	public float ADelayMax;

	public bool SpawnB;
    public float BDelayMin;
    private float BDelayCounter = 0;
    public float BDelayMax;

    public bool SpawnC;
	public float CDelayMin;
	private float CDelayCounter = 0;
	public float CDelayMax;

	public bool SpawnD;
	
	public GameObject TypeA;
	public GameObject TypeB;

	void Update () {
		if (SpawnA && ADelayCounter <= 0)
		{
			Instantiate(TypeA, new Vector3(999,999,999), Quaternion.Euler(0, 0, 0));
			ADelayCounter = Random.Range(ADelayMin, ADelayMax);
		}
		ADelayCounter -= Time.deltaTime;
		if (SpawnB && BDelayCounter <= 0)
		{
			Instantiate(TypeB, new Vector3(999, 999, 999), Quaternion.Euler(0, 0, 0));
			BDelayCounter = Random.Range(BDelayMin, BDelayMax);
		}
		BDelayCounter -= Time.deltaTime;
    }
}
