using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeD : MonoBehaviour {

    private bool LR = false;
    private Vector3 BL;
    private Vector3 TR;

    public float Speed = 8;
	public GameObject Flag;

	private GameObject NewFlag;

	void Start () {

        BL = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)); //Get the top left corner at Z=0
        TR = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 10));
		
        transform.position = new Vector2 (Random.Range(BL.x,TR.x),TR.y+10);
	}

	void OnBecameInvisible()
	{
        //#EditorCamerasMatter
		Destroy(gameObject);
	}
}
