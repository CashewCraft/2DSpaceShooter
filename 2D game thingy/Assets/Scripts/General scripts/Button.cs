using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	public GameObject[] DeletionList;

	public void OnButtonClick()
	{
		foreach (GameObject i in DeletionList)
		{
			Destroy(i);
		}
		SceneManager.LoadScene("Base", LoadSceneMode.Additive);
		SceneManager.UnloadScene("Menu");
	}
}
