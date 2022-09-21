using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_Generator : MonoBehaviour, IInteractable
{
	public Inventory inv;
	public bool canInteract() {
		return true;
	}

	public void Interact() {
		inv.AddMoney(10);
	}



	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
