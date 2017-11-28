using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour {
    void SetLives(int remaining)
    {
        print("Setting lives to " + remaining);
        for (int i = 0; i < 6; i++)
        {
            if (i > remaining)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            }
            else
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
        }
    }
}
