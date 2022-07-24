using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icebox : MonoBehaviour, IInteractable {

    public Tool tool;

    public List<RecipieSO> Recipies;

    public bool canInteract() {
        return tool.canAct();
    }

	public void Interact() {
        tool.act();

    }

    void Start() {
        tool = new Tool(name);
        tool.begin();
    }
}
