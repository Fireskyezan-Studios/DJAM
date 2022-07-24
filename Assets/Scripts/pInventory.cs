using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pInventory : MonoBehaviour
{
    public Inventory inventory;

	[SerializeField] private GameObject inv;

	[SerializeField] private GameObject inter;

	public void Update() {
		if (Input.GetButtonDown("Inventory")) {
			if (inv.active) {
				inv.SetActive(false);
			} else {
				if (!inter.active) {
					inv.SetActive(true);
				}
			}

		}

		if (Input.GetButtonDown("Interact")) {
			if (inter.active) {
				inter.SetActive(false);
			}

		}
	}

}
