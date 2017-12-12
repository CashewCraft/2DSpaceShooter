using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLinr : MonoBehaviour {

    public float stageTimer = 30;
    public float stageReset = 40;
    int stageIndex = 0;

    public Spawner I;

	void Update () {
		if (stageTimer <= 0)
        {
            stageTimer = stageReset;
            stageIndex++;
        }
        stageTimer -= Time.deltaTime;
        switch (stageIndex)
        {
            case 0:
                I.SpawnA = true;
                break;
            case 1:
                I.SpawnA = true;
                I.SpawnB = true;
                break;
            case 2:
                I.SpawnA = true;
                I.SpawnD = true;
                I.SpawnB = true;
                I.SpawnE = true;
                break;
            case 3:
                I.SpawnE = false;
                I.SpawnC = true;
                I.SpawnA = false;
                break;
			case 4:
				//End scene
				break;
        }
	}
}
