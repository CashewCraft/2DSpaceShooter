using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeB : MonoBehaviour {

    private bool LR;
    private Vector3 BL;
    private Vector3 TL;

    public float Speed = 12;

    public float DelayToTurn;

    void Start()
    {
        LR = (Random.Range(0, 2) == 0);

        int OffSet = -2; //how far off the side of the screen the enemies will spawn

        Vector3 BL = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)); //Get the top left corner at Z=0
        Vector3 TR = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 10));

        if (LR)
        {
            transform.position = new Vector3(TR.x - OffSet, Random.Range(0, TR.y + 3.5f) + (TR.y * 0.75f), 0);
        }
        else
        {
            transform.position = new Vector3(BL.x + OffSet, Random.Range(0, TR.y + 3.5f) + (TR.y * 0.75f), 0);
        }
        transform.right = new Vector3(Random.Range(BL.x / 2, TR.x / 2), TR.y-3f, 0) - transform.position;
        
    }

    void Update()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
        DelayToTurn -= Time.deltaTime;
        if (DelayToTurn <= 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-90), Time.time * 0.02f);
        }
    }
}
