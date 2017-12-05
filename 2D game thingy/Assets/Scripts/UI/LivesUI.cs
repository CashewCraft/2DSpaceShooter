using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour {
    void SetLives(StoreItem it)
    {
        print("Setting lives to " + it.remain);
        for (int i = 0; i < 6; i++)
        {
            if (i > it.remain-1)
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
				transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = it.spriteLis[i];
				transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 0);
			}
            else
            {
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
				transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = it.spriteLis[i];
				if (i == it.index)
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
