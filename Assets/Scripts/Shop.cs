using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, IInteractable {



    [SerializeField] private GameObject shop;

    public bool canInteract() {
		return true;
    }

	public void Interact() {
		if (shop.activeInHierarchy) {
			shop.SetActive(false);
			GameObject.Find("Player").GetComponent<PlayerController>().movementEnabled = true;
		} else {
			shop.SetActive(true);
			GameObject.Find("Player").GetComponent<PlayerController>().movementEnabled = false;
		}

	}

    void Start() {
    }
}
