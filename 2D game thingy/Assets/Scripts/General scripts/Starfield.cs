using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour {

	public int NoStars;
	private ParticleSystem.Particle[] points;
	private int[] distances; //simulated distance from camera for paralax(?) effect

	private Vector3 BL;
	private Vector3 TR;

	void Start () {

		BL = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)); //Get the bottom left corner at Z=0
		BL.x = (BL.x * 0.8f);
		TR = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 10)); //Get the top right corner at Z=0
		TR.x = (TR.x * 0.8f);

		distances = new int[NoStars];

		points = new ParticleSystem.Particle[NoStars];
		for (int i = 0; i < NoStars; i++)
		{
			distances[i] = Random.Range(1, 10);
			points[i].position = new Vector2(Random.Range(BL.x, TR.x), Random.Range(BL.y, TR.y));
			
			points[i].startSize = 1.0f/distances[i];
			points[i].startColor = new Color(1,1,1,0.4f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<ParticleSystem>().SetParticles(points,points.Length);
		for (int i = 0; i < NoStars; i++)
		{
			points[i].position -= new Vector3(0, 0.2f / distances[i],0);
			if (points[i].position.y < BL.y-2)
			{
				points[i].position = new Vector2(Random.Range(BL.x, TR.x), TR.y+2);
			}
		}
    }
}
