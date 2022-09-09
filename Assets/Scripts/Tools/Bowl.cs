using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour, IInteractable {

	public Tool tool;


	[SerializeField] private GameObject inter;

	public bool canInteract() {
		return tool.canAct();
	}

	public void Interact() {
		tool.act(TOOL.Bowl, inter);

	}

	void Start() {
		tool = new Tool(name);
		tool.begin();
	}
}
