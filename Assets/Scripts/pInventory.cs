using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pInventory : MonoBehaviour
{
    public Inventory inventory;


	[SerializeField] private GameObject inter;

	public void Update() {


	}

	public void inactivate(PointerEventData eventData) {
		GameObject.Find("Interaction").GetComponent<DisplayInteraction>().FindNearestSlot2(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
	}

}
