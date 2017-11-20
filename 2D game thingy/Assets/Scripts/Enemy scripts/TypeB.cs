using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeB : MonoBehaviour {

    private bool LR;
    private Vector3 BL;
    private Vector3 TL;

	public GameObject BeamHandler;

	public float Speed = 12;

    public float DelayMin;
	public float DelayMax;
	private float DelayToTurn;

	private bool[] IsMoving = new bool[4] { false, false, false, false }; //used for preventing ships "popping" in and out of formation

	private float[,] formations = new float[3,12] {
		{ -0.3f, 0.3f, 0.3f, -0.3f, //posX
          1.2f, 0.5f, -0.5f, -1.2f, //posY
          0,    0.5f,    0.5f,     0  //firedelay
		},
		{ 0.3f, 0.3f, 0.3f, 0.3f, //posX
          1.2f, 0.5f, -0.5f, -1.2f, //posY
          0,    0.5f,    1,     1.5f  //firedelay
		},
		{ -0.3f, 0.4f, -1, -0.3f, //posX
          0.8f,  0,    0,    -0.8f, //posY
          0.5f,     0,    1,    1.5f  //firedelay
		}
	};

	private int SelectedFormation;

	void Start()
    {
        LR = (Random.Range(0, 2) == 0);

		DelayToTurn = Random.Range(DelayMin, DelayMax);
		SelectedFormation = Random.Range(0, 3);
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
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-90), Time.time * 0.04f);
			SetFormation(SelectedFormation);
        }
    }

	void SetFormation(int Selection)
	{
		for (int i = 0; i < 5; i++)
		{
			try
			{
				if ((Vector2)transform.Find("Fighter("+i+")").position != new Vector2(formations[Selection, i], formations[Selection, (i+4)]) && !IsMoving[i])
				{
					transform.Find("Fighter("+i+")").localPosition = new Vector2(formations[Selection, i], formations[Selection, i+4]);
					IsMoving[i] = true;
                }
				if (formations[Selection,(i+8)] <= 0)
				{
					GameObject l = Instantiate(BeamHandler, transform.Find("Fighter("+i+")"));
					l.tag = transform.tag;
					formations[Selection, (i + 8)] = 256;
                }
				else
				{
					formations[Selection, (i + 8)] -= Time.deltaTime;
                }
			}
			catch{ } //some ships might have been destroyed
		}
	}

	//Ok look, this is VERY VERY important to have, as it destroys the enemy (even though it doesn't seem to think that it is)
	//I'm not entirely sure *why* it destroys it since it's not really got a visible sprite, but apparently a nonfunctional renderer is just as good as a working one.
	void OnBecameInvisible()
	{
		//#EditorCamerasMatter
		Destroy(gameObject);
	}
}
