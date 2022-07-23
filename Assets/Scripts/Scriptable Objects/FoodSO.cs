using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Food")]
public class FoodSO : ScriptableObject
{
	public string foodName;
	public Sprite sprite;
	// for basic ingredients for sale, add 50% to value
	public int value;
	

}
