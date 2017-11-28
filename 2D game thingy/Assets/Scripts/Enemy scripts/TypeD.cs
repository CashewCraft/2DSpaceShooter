using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeD : MonoBehaviour {

    private bool LR = false;
    public Vector3 BL;
    public Vector3 TR;

    public float Speed = 8;
	public GameObject Flag;

	private GameObject NewFlag;

	void Start () {
        transform.position = new Vector2 (Random.Range(BL.x,TR.x),TR.y+10);
	}

	void OnBecameInvisible()
	{
        //#EditorCamerasMatter
		Destroy(gameObject);
	}
}
