using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeC : MonoBehaviour {

    private bool LR = false;
    private Vector3 BL;
    private Vector3 TR;

    public float Speed = 8;
	public GameObject Flag;

	private GameObject NewFlag;

	void Start () {

        int OffSet = 0; //how far off the side of the screen the enemies will spawn

        BL = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)); //Get the top left corner at Z=0
        TR = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 10));
		
        transform.position = TR;
	}

	void Update ()
    {
		if (LR)
		{
			transform.position += transform.right * Speed * Time.deltaTime;
		}
		else
		{
			transform.position -= transform.right * Speed * Time.deltaTime;
		}
		if (LR && transform.position.x >= TR.x)
		{
			LR = false;
		}
		else if (!LR && transform.position.x <= BL.x)
		{
			LR = true;
		}
	}

	void OnBecameInvisible()
	{
		//#EditorCamerasMatter
		Destroy(gameObject);
	}
}
