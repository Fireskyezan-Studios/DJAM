using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour, IInteractable {

    public Tool tool;

    
    public bool canInteract() {
        return tool.canAct();
    }

	public void Interact() {
        tool.act();

    }

    void Start() {
        tool = new Tool();
        tool.begin();
    }
}
