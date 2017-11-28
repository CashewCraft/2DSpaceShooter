using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour {
    void SetHealth(int val)
    {
        transform.GetChild(0).localScale = new Vector3((float)val/100,1,1);
        transform.GetChild(0).localPosition = new Vector3((1-((float)val/100))/2, 0,-1);
    }
}
