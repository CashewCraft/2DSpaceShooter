using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTypes : MonoBehaviour
{
	private string[] NameList = new string[2] { "Arrow", "Escort" };

	public Sprite[] Sprites = new Sprite[2];
	public GameObject[] Bullets = new GameObject[2];
	public GameObject[] Secondary = new GameObject[2];

	public int GetIndexFromName(string Name)
	{
		return System.Array.IndexOf(NameList, Name);
	}
}
