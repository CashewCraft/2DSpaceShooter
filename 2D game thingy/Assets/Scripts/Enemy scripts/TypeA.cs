using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeA : MonoBehaviour {

    private bool LR;
    private Vector3 BL;
    private Vector3 TL;

    public float Speed = 8;
	public GameObject Flag;

	private GameObject NewFlag;

	void Start () {
        LR = (Random.Range(0, 2) == 0);

        int OffSet = 0; //how far off the side of the screen the enemies will spawn

        Vector3 BL = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)); //Get the top left corner at Z=0
        Vector3 TR = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 10));

        if (LR)
        {
            transform.position = new Vector3(TR.x - OffSet, Random.Range(0, TR.y*2) + (TR.y * 0.75f),0);
        }
        else
        {
            transform.position = new Vector3(BL.x + OffSet, Random.Range(0, TR.y*2) + (TR.y * 0.75f), 0);
        }

        transform.right = new Vector3(Random.Range(BL.x / 2, TR.x / 2), BL.y, 0) - transform.position;

		Transform player = GameObject.Find("ChaseHead").transform.GetChild(0).GetChild(1);
		NewFlag = Instantiate(Flag, player.position, Quaternion.Euler(0,0,(transform.rotation.eulerAngles.z)+90), player);
		NewFlag.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0); //Make it invisible initially so it doesn't "pop" into correct rotation while visible
		NewFlag.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
	}

	void Update ()
    {
		transform.position += transform.right*Speed*Time.deltaTime;
	}

	void OnBecameInvisible()
	{
		//#EditorCamerasMatter
        Destroy(gameObject);
	}
}
