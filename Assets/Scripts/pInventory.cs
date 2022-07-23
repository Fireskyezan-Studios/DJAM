using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pInventory : MonoBehaviour
{
    public Inventory inventory;

	[SerializeField] private GameObject inv;

	public void Update() {
		if (Input.GetButtonDown("Inventory")) {
			if (inv.activeSelf) {
				inv.SetActive(false);
			} else {
				inv.SetActive(true);
			}

		}
	}

}
