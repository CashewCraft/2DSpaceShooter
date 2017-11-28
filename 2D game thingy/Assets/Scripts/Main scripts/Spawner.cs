using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Vector3 BL;
	public Vector3 TR;

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
    public float DDelayMin;
    private float DDelayCounter = 0;
    public float DDelayMax;

    public GameObject TypeA;
	public GameObject TypeB;
    public GameObject TypeC;
    public GameObject TypeD;

    void Update () {
		if (SpawnA && ADelayCounter <= 0)
		{
			GameObject Nenemy = Instantiate(TypeA, new Vector3(999,999,999), Quaternion.Euler(0, 0, 0));
			Nenemy.transform.GetComponent<TypeA>().BL = BL;
			Nenemy.transform.GetComponent<TypeA>().TR = TR;
			ADelayCounter = Random.Range(ADelayMin, ADelayMax);
		}
		ADelayCounter -= Time.deltaTime;
		if (SpawnB && BDelayCounter <= 0)
		{
			GameObject Nenemy = Instantiate(TypeB, new Vector3(999, 999, 999), Quaternion.Euler(0, 0, 0));
			Nenemy.transform.GetComponent<TypeB>().BL = BL;
			Nenemy.transform.GetComponent<TypeB>().TR = TR;
			BDelayCounter = Random.Range(BDelayMin, BDelayMax);
		}
		BDelayCounter -= Time.deltaTime;
        if (SpawnC && CDelayCounter <= 0)
        {
			GameObject Nenemy = Instantiate(TypeC, new Vector3(999, 999, 999), Quaternion.Euler(0, 0, 0));
			Nenemy.transform.GetComponent<TypeC>().BL = BL;
			Nenemy.transform.GetComponent<TypeC>().TR = TR;
			CDelayCounter = Random.Range(CDelayMin, CDelayMax);
        }
        CDelayCounter -= Time.deltaTime;
        if (SpawnD && DDelayCounter <= 0)
        {
			GameObject Nenemy = Instantiate(TypeD, new Vector3(999, 999, 999), Quaternion.Euler(0, 0, 0));
			Nenemy.transform.GetComponent<TypeD>().BL = BL;
			Nenemy.transform.GetComponent<TypeD>().TR = TR;
			DDelayCounter = Random.Range(DDelayMin, DDelayMax);
        }
        DDelayCounter -= Time.deltaTime;
    }
}
