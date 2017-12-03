using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour {
    void SetLives(int[] remainingindex)
    {
        print("Setting lives to " + remainingindex[0]);
        for (int i = 0; i < 6; i++)
        {
            if (i > remainingindex[0]-1)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
				transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 0);
			}
            else
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
				if (i == remainingindex[1])
				{
					transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 255);
				}
				else
				{
					transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 0);
				}
			}
        }
    }
}
