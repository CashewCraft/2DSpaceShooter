﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Organiser : MonoBehaviour {

	void Start () {
		//Organiser script to deal with scaling everything to different aspect ratios & resolutions
		//Much better than just having black bars

		while (Camera.allCamerasCount > 1)
		{
			Destroy(Camera.main); //Delete the main camera left over from the last scene
		}

		Vector3 BL = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)); //Get the bottom left corner at Z=0
		BL.x = (BL.x * 0.8f);
		Vector3 TR = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 10)); //Get the top right corner at Z=0
		TR.x = (TR.x * 0.8f);

		print("BL = " + BL);
		print("TR = " + TR);

		transform.GetChild(0).GetComponent<Spawner>().BL = BL; //Get the Top-to-bottom hight
		transform.GetChild(0).GetComponent<Spawner>().TR = TR; //Get the Top-to-bottom hight

		transform.GetChild(2).GetComponent<Movement>().PlayAreaX = -(BL.x); //Get the Top-to-bottom hight (BL is negative)
		transform.GetChild(2).GetComponent<Movement>().PlayAreaY = -(BL.y); //Get the Top-to-bottom hight
		
		transform.GetChild(2).position = new Vector3(0, BL.y - (BL.y / 15),0); //Place the player at the starting position
		transform.GetChild(3).position = new Vector3(0, -BL.y, 0); //Place the chase head at the topmost point

		transform.GetChild(1).position = transform.GetChild(1).position += new Vector3((TR.x/4), 0,0); //shift the camera so the right side of the screen is free for UI

        transform.GetChild(4).localScale = new Vector3((TR.x / 4)*2, TR.y*2,1);
        transform.GetChild(4).localPosition = new Vector3(TR.x+(TR.x / 4), 0,0);
        transform.GetChild(4).parent = transform.GetChild(1); //Move the UI container under the camera so it remains with it
		transform.GetChild(4).parent = transform.GetChild(1);

		transform.GetChild(1).parent = transform.GetChild(0); //make the camera and player move as one, the hierarchy adjusts as we do this so we can just copy-paste 

        transform.GetChild(1).GetComponent<Movement>().SpeedX = (-(BL.x) / 16) * transform.GetChild(1).GetComponent<Movement>().Speed; //Change the speed of the player and it's bullets
        transform.GetChild(1).GetComponent<Movement>().SpeedY = transform.GetChild(1).GetComponent<Movement>().SpeedX * (-(BL.x) / -(BL.y)); //This is important for extremely big/small resolutions

        transform.GetChild(1).parent = transform.GetChild(0); //Finish moving the player

		transform.GetChild(0).parent = transform.GetChild(1); //Make the chase head lead everything else

		transform.GetChild(0).parent = null; //Unparent everything so it doesn't suicide with us

		Destroy(transform.gameObject); //Our purpose is complete, goodbye cruel world!
	}
}
