using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookbook : MonoBehaviour, IInteractable
{

	private List<RecipieSO> recipies;

    public GameObject dInteraction;

	public GameObject inter;

	public GameObject moneyText;

	// Start is called before the first frame update
	void Start()
    {
        recipies = dInteraction.GetComponent<DisplayInteraction>().recipies;



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool canInteract() {
        return true;
    }

    public void Interact() {
		if (inter.activeInHierarchy) {
			inter.SetActive(false);
			moneyText.SetActive(true);
			GameObject.Find("Player").GetComponent<PlayerController>().movementEnabled = true;
		} else {
			moneyText.SetActive(false);
			inter.SetActive(true);
			GameObject.Find("Player").GetComponent<PlayerController>().movementEnabled = false;
		}

	}
}
