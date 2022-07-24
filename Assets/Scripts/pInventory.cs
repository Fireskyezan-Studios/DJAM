using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pInventory : MonoBehaviour
{
    public Inventory inventory;

	[SerializeField] private GameObject inv;

	[SerializeField] private GameObject inter;

	public void Update() {
		if (Input.GetButtonDown("Inventory")) {
			if (inv.activeInHierarchy) {
				inv.SetActive(false);
			} else {
				if (!inter.activeInHierarchy) {
					inv.SetActive(true);
				}
			}

		}

		if (Input.GetButtonDown("Interact")) {
			if (inter.activeInHierarchy) {
				inter.SetActive(false);
			}

		}
	}

	public void inactivate(PointerEventData eventData) {
		if (inv.activeInHierarchy) {
			GameObject.Find("Inventory").GetComponent<DisplayInventory>().FindNearestSlot2(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
		} else {
			GameObject.Find("Interaction").GetComponent<DisplayInteraction>().FindNearestSlot2(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
		}
	}

}
