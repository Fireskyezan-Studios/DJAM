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
    public void act(TOOL tool, GameObject inter, GameObject inv) {
        if (inter.activeInHierarchy) {
            inter.SetActive(false);
        } else {
            if (!inv.activeInHierarchy) {
                inter.SetActive(true);
            }
        }

        GameObject.Find("Interaction").GetComponent<DisplayInteraction>().ChangeText(tool.ToString());
    }

    // Determines whether an item can be interacted with. Run in the canInteract method (from IInteractable)
    public bool canAct () {
        return true;
    }

    public FoodSO Cook (RecipieSO recipie, TOOL tool) {
        return recipie.product;
	}

}
