using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTypes : MonoBehaviour
{
	private string[] NameList = new string[1] { "Arrow" };

	public Sprite[] Sprites = new Sprite[1];
	public GameObject[] Bullets = new GameObject[1];
	public GameObject[] Secondary = new GameObject[1];

	public int GetIndexFromName(string Name)
	{
		return System.Array.IndexOf(NameList, Name);
	}
}
