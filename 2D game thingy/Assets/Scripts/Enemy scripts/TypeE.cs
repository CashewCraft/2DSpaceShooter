using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeE : MonoBehaviour {

	public Vector3 BL;
	public Vector3 TR;

	public float pulseRate;
	private float timer = 0;

	public float speed;

	public GameObject BeamHandler;

	void Start()
	{
		float Ypos = TR.y + 2 + Random.Range(0, TR.y*2);
		transform.position = new Vector2(0, Ypos);
		transform.GetChild(0).localPosition = new Vector2(BL.x, -1);
		transform.GetChild(1).localPosition = new Vector2(TR.x, -1);
	}
        
	void Update ()
	{
		transform.position -= new Vector3(0, Time.deltaTime * speed,0);
		if (timer <= 0)
		{
			timer = pulseRate;
			GameObject l = Instantiate(BeamHandler, transform.GetChild(0));
			l.tag = transform.tag;
			l = Instantiate(BeamHandler, transform.GetChild(1));
			l.tag = transform.tag;
		}
		timer -= Time.deltaTime;
	}
}
