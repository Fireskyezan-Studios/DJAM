using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class pInventory : MonoBehaviour
{
    public Inventory inventory;
	private int i;
	public int j;
	public TextMeshProUGUI moneyText;
	public bool insufficientFunds = false;

	[SerializeField] private GameObject inter;

	public void Update() {
		if (i%10 == 0) {
			if(!insufficientFunds) {
				moneyText.color = Color.white;
				moneyText.text = "Funds: " + inventory.money.ToString();
			} else {
				moneyText.color = Color.red;
				moneyText.text = "INSUFFICIENT FUNDS";
				j++;
				if (j == 30) {
					insufficientFunds = false;
					j = 0;
				}
			}
			
		}
		i++;
	}

	public Inventory getInv() {
		return inventory;
	}

	public void addInv(FoodSO _food) {
		inventory.AddItem(_food, 1);
	}

	public void inactivate(PointerEventData eventData) {
		GameObject.Find("Interaction").GetComponent<DisplayInteraction>().FindNearestSlot2(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
	}

}
