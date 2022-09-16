using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

	public FoodSO food;
	public GameObject player;

	public bool canInteract() {
		return tool.canAct();
	}

	public void Interact() {
		tool.act(TOOL.Oven, inter);

	}

	void Start() {
		player = GameObject.Find("Player");
	}
}