using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClick : MonoBehaviour {

	public FoodSO food;
	private GameObject player;
	public Inventory inventory;
	public pInventory pinv;

	public void Click () {
		if (inventory.canAfford(food.value)) {
			inventory.AddItem(food, 1);
			inventory.subtractMoney(food.value);
		} else {
			pinv.j = 0;
			pinv.insufficientFunds = true;
		}
		

	}



	

	

	void Start() {
		player = GameObject.Find("Player");
		pinv = player.GetComponent<pInventory>();
	}
}