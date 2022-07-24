using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Food")]
public class FoodSO : ScriptableObject
{
	public Sprite sprite;
	public string foodName;
	[TextArea(5,10)]
	public string description;
	// for basic ingredients for sale, add 50% to value
	public int value;
	public GameObject prefab;

	public void Awake() {
		foodName = name;
	}

}
