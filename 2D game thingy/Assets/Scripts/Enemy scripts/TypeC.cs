using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeC : MonoBehaviour {

    private bool LR = false;
    public Vector3 BL;
    public Vector3 TR;

    public float Speed = 8;

	private GameObject NewFlag;

	void Start () {
		
        transform.position = new Vector2 (0,TR.y);
	}

	void OnBecameInvisible()
	{
        //#EditorCamerasMatter
		Destroy(gameObject);
	}
}
