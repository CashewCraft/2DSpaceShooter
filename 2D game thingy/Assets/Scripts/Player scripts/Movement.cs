using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float Speed = 8.0f; //speed as a function of the screen size

	public float PlayAreaY = 0; //Note: these are half the actual values for ease of use
	public float PlayAreaX = 0;

    public float SpeedX;
    public float SpeedY;

	void Start()
	{
		SpeedX = (PlayAreaX / 16) * Speed;
		SpeedY = SpeedX * (PlayAreaX / PlayAreaY);
	}

    void Update () {
        if (Input.GetKey("w") && transform.localPosition.y < (PlayAreaY - (PlayAreaY / 15)) )
        {
            transform.Translate(new Vector3(0,(SpeedY*1.2f) * Time.deltaTime,0));
            //Move upwards at a rate of Base*1.2
        }
        else if(Input.GetKey("s") && transform.localPosition.y > -(PlayAreaY - (PlayAreaY / 15)) )
        {
            transform.Translate(new Vector3(0,((-SpeedY/8)*7) * Time.deltaTime, 0));
            //Move downwards at a rate of 7/8ths Base
        }
        else if (!Input.GetKey("w") && transform.localPosition.y > -(PlayAreaY - (PlayAreaY / 15)) )
        {
            transform.Translate(new Vector3(0,((-SpeedY / 4) * 2) * Time.deltaTime, 0));
            //Move downwards at a rate of 1/2 Base while not holding any horizontal movement key
        }

        if (Input.GetKey("d") && transform.localPosition.x < (PlayAreaX - (PlayAreaX / 10)) )
        {
            transform.Translate(new Vector3(SpeedX*Time.deltaTime,0,0));
            //Move up at base
        }
        else if (Input.GetKey("a") && transform.localPosition.x > -(PlayAreaX - (PlayAreaX / 10)) )
        {
            transform.Translate(new Vector3(-SpeedX*Time.deltaTime, 0,0));
        }

        if (transform.localPosition.y > (PlayAreaY - (PlayAreaY / 15))) //Reset positions if the player goes OOB
        {
            transform.localPosition = new Vector3(transform.localPosition.x,(PlayAreaY - (PlayAreaY / 15)), transform.localPosition.z);
        }
        else if(transform.localPosition.y < -(PlayAreaY - (PlayAreaY / 15)))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -(PlayAreaY - (PlayAreaY / 15)), transform.localPosition.z);
        }
        if (transform.localPosition.x > (PlayAreaX - (PlayAreaX / 10)))
        {
            transform.localPosition = new Vector3((PlayAreaX - (PlayAreaX / 10)), transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x < -(PlayAreaX - (PlayAreaX / 10)))
        {
            transform.localPosition = new Vector3(-(PlayAreaX - (PlayAreaX / 10)), transform.localPosition.y, transform.localPosition.z);
        }
    }
}
