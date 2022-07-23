using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {

    public bool canInteract();

    public void Interact();

    //Display an 'interact' prompt when in interactRange
    //void inRange(bool entering);
}
