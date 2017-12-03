using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretControl : MonoBehaviour {

	public GameObject Shield;
	private GameObject ShieldInst;

	private Transform Turret1;
	private Transform Turret2;

	public GameObject projectile;
	
	private int PatternTickCounter1 = 0;
	private int PatternTickLimit1 = 0;
	private int P1dir;

	private int PatternTickCounter2 = 0;
	private int PatternTickLimit2 = 0;
	private int P2dir;

	public float fireRate = 4f;
	private float Timer;
	public int damage = 1;

	public List<int>[] Patterns;
	private int[] Pattern = new int[0];
	private int PatternIndex;
	private int PatternPos = 0;

	private bool Tick = true;

	void Start()
	{
		Patterns = new List<int>[8] {
		new List<int> { 1, 45, 5, 1, 50, 15, 1, -5, -45, 1, -15, -50 }, new List<int> { 1, 50, 15, 1, 45, 5, 1, -15, -50, 1, -5, -45 },
		new List<int> { -1, 45, 5, -1, 50, 15, -1, -5, -45, -1, -15, -50 }, new List<int> { -1, 50, 15, -1, 45, 5, -1, -15, -50, -1, -5, -45 },
		new List<int> { 1, 20, 0, -1, 20, 0, 1, -25, -50, 1, -25, -50, -1, -25, -50, -1, -25, -50 },
        new List<int> { -1, 20, 0, 1, 20, 0, -1, -25, -50, -1, -25, -50, 1, -25, -50, 1, -25, -50 },
        new List<int> { 1, 30, 0, -1, 30, 0 },
        new List<int> { 1, 60, 30, -1, 60, 30, 1, 26, 0, -1, 26, 0 }
        };
        Turret1 = transform.GetChild(0);
		Turret2 = transform.GetChild(1);

		ShieldInst = Instantiate(Shield, transform.parent.position, transform.rotation, transform.parent);
	}

	void Update () {
		if (Timer <= 0)
		{
			if (ShieldInst == null) { ShieldInst = Instantiate(Shield, transform.parent.position, transform.rotation, transform.parent); }
			if (PatternTickCounter1 > PatternTickLimit1 && PatternTickCounter1 > PatternTickLimit1)
			{
				if (PatternTickCounter1 > PatternTickLimit1) {
					Turret1.transform.rotation = Quaternion.Euler(0, 0, 0 + P1dir * PatternTickCounter1);
					PatternTickCounter1--;
				}
				if (PatternTickCounter2 > PatternTickLimit2)
				{
					Turret2.transform.rotation = Quaternion.Euler(0, 0, 0 + P2dir*PatternTickCounter2);
					PatternTickCounter2--;
				}
				Fire();
			}
			else
			{
				if (PatternPos == Pattern.GetLength(0))
				{
                    PatternIndex = Random.Range(0, Pattern.GetLength(0));
					Pattern = Patterns.ElementAt(PatternIndex).ToArray();
					PatternPos = 0;
					Timer = fireRate;
					//print("Reset pattern");
					Destroy(ShieldInst);
				}
				else
				{
					//print("Setting Counter for turret 1 to " + Pattern[PatternPos+1] + " with a limit of " + Pattern[PatternPos + 2] + ", dir counter "+ Pattern[PatternPos]);
					P1dir = Pattern[PatternPos];
					PatternPos++;
                    PatternTickCounter1 = Pattern[PatternPos];
					PatternPos++;
					PatternTickLimit1 = Pattern[PatternPos];
					PatternPos++;
					//print("Setting Counter for turret 2 to " + Pattern[PatternPos + 1] + " with a limit of " + Pattern[PatternPos + 2] + ", dir counter " + Pattern[PatternPos]);
					P2dir = Pattern[PatternPos];
					PatternPos++;
					PatternTickCounter2 = Pattern[PatternPos];
					PatternPos++;
					PatternTickLimit2 = Pattern[PatternPos];
					PatternPos++;
				}
			}
		}
		else
		{
			Timer -= Time.deltaTime;
		}
	}

	void Fire()
	{
		if (Tick)
		{
			GameObject bullet1 = Instantiate(projectile, Turret1.GetChild(0).position, Quaternion.Euler(0, 0, Turret1.rotation.eulerAngles.z + 180), transform.parent.parent.Find("BulletHolder"));
			GameObject bullet2 = Instantiate(projectile, Turret2.GetChild(0).position, Quaternion.Euler(0, 0, Turret2.rotation.eulerAngles.z + 180), transform.parent.parent.Find("BulletHolder"));
			bullet1.GetComponent<Bullet>().Damage = damage;
			bullet1.transform.tag = transform.tag;
			bullet1.GetComponent<Bullet>().speed = 20;
			bullet2.GetComponent<Bullet>().Damage = damage;
			bullet2.transform.tag = transform.tag;
			bullet2.GetComponent<Bullet>().speed = (20);
			Tick = false;
		}
		else { Tick = true; }
	}
}
