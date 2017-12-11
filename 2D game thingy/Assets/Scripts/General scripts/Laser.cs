using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public GameObject Flag;
	public GameObject Beam;

	private float counter = 1;
	private float Beamcounter = 1;

	public float PulseRate = 0.3f;
	private float PulseCounter;

	private int Pulses = 1;

	public GameObject projectile;

	public int Damage;

	public void Start()
	{
		PulseCounter = 0;
		Flag = Instantiate(Flag, transform.position, transform.rotation,transform);
		Beam = Instantiate(Beam, transform);
		Beam.transform.localPosition = new Vector3(Beam.transform.localScale.y / 2, 0, 1);
        Beam.transform.localRotation = Quaternion.Euler(0, 0, 90);
        Beam.GetComponent<SpriteRenderer>().color = new Color(Beam.GetComponent<SpriteRenderer>().color.r, Beam.GetComponent<SpriteRenderer>().color.g, Beam.GetComponent<SpriteRenderer>().color.b, 0);
	}

	public void Update()
	{
		if (counter > 0)
		{
			Flag.transform.localScale = new Vector3(counter*3,counter*3,counter*3);
			counter -= Time.deltaTime*2.5f;
		}
		else
		{
			if (Beamcounter > 0)
			{
				Beam.GetComponent<SpriteRenderer>().color = new Color(Beam.GetComponent<SpriteRenderer>().color.r, Beam.GetComponent<SpriteRenderer>().color.g, Beam.GetComponent<SpriteRenderer>().color.b, Beamcounter);
				Beam.transform.localScale = new Vector3(Beamcounter, Beam.transform.localScale.y, 1);
				Beamcounter -= Time.deltaTime;
				PulseCounter -= Time.deltaTime;
				if (PulseCounter <= 0 && Beam.GetComponent<SpriteRenderer>().color.a > (150.0f/255))
				{
					print("beep beep");
					PulseCounter = PulseRate;
					GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(0,0,-90), transform);
					bullet.GetComponent<Bullet>().Damage = Damage/Pulses;
					Pulses++;
                    bullet.transform.tag = transform.tag;
					bullet.GetComponent<Bullet>().speed = 80;
				}
            }
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
