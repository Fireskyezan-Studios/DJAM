using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TOOL {
	Icebox,
	Stove,
	Oven,
	Bowl,
	Keg,
	Cookbook
}

[CreateAssetMenu(fileName = "New Recipie", menuName = "Recipie")]
public class RecipieSO : ScriptableObject
{

	public List<FoodSO> ingredients;

	// unused, meant for labelling.
	// recipies are put under their respective tool in editor
	public TOOL tool;

	// In seconds
	public int cookingDuration;
	public FoodSO product;


}
