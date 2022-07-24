using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool
{

    private string _name;


    public Tool(string tName) { 
        _name = tName;
    }

    // --------Getters & Setters----------
    public string name {
        get { return _name; }
        set { _name = value; }
    }

    // Run in local Start method
    public void begin () {
        //Debug.Log("Start");
    }

    // Run in local Interact method (from IInteractable)
    public void act(String name, GameObject inter, GameObject inv) {
        if (inter.activeSelf) {
            inter.SetActive(false);
        } else {
            if (!inv.activeSelf) {
                inter.SetActive(true);
            }
        }
    }

    // Determines whether an item can be interacted with. Run in the canInteract method (from IInteractable)
    public bool canAct () {
        return true;
    }


}
