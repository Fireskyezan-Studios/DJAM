using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool
{

    public Tool() { 
    }

    // --------Getters & Setters----------

          
    // Run in local Start method
    public void begin () {
        Debug.Log("Start");
    }

    // Run in local Interact method (from IInteractable)
    public void act() {
        Debug.Log("Interact");
    }

    // Determines whether an item can be interacted with. Run in the canInteract method (from IInteractable)
    public bool canAct () {
        return true;
    }


}
