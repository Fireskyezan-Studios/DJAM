using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;



public class DisplayInteraction : MonoBehaviour, IDropHandler
{

    public List<SlotSO> slots;

    public Inventory inventory;

    public int xStart;
    public int yStart;


    public int xSpacing;

    public int ySpacing;

    public int columns;
    public int rows;
    private Vector2 currentLoc;

    private TOOL selected;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    public void ChangeText(TOOL tool) {
        GetComponentInChildren<TextMeshProUGUI>().text = tool.ToString();
        selected = tool;
	}

    public void FindNearestSlot2(Vector2 loc) {
        SlotSO smallest = slots[0];
        float smallestD = 10000;
        for (int i = 0; i < slots.Count; i++) {
            if (Vector2.Distance(slots[i].slot.GetComponent<RectTransform>().anchoredPosition, loc) < smallestD) {
                if (slots[i].taken) {
                    smallest = slots[i];
                    smallestD = Vector2.Distance(slots[i].slot.GetComponent<RectTransform>().anchoredPosition, loc);
                }
            }

        }
        smallest.food = null;
        smallest.taken = false;

    }

    public void OnDrop(PointerEventData eventData) {
        //Debug.Log("Drop");
        if (eventData.pointerDrag != null) {
            //GameObject.Find("Inventory/Background")
            currentLoc = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(currentLoc, ).GetComponent<RectTransform>().anchoredPosition;
        }
    }

    //NOTE TO SELF: THINK ABOUT EXTRA CRAFTING SLOTS! LIST APPEND??
    public GameObject FindNearestSlot(Vector2 loc, FoodSO sustinence) {
        SlotSO smallest = slots[0];
        float smallestD = 10000;
        for (int i = 0; i < slots.Count; i++) {
			if (Vector2.Distance(slots[i].slot.GetComponent<RectTransform>().anchoredPosition, loc) < smallestD) {
                if (!slots[i].taken) {
                    smallest = slots[i];
                    smallestD = Vector2.Distance(slots[i].slot.GetComponent<RectTransform>().anchoredPosition, loc);
                }
            }
        }
        smallest.food = sustinence;
        smallest.taken = true;

        /*if (smallest.slot == slots[40]) {
			slots[40].food = 
		} else if (smallest.slot == slots[41]) {

		}*/

        return smallest.slot;

    }

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slots.Count; i++) {
            slots[i].taken = false;
        }
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay() {

        for (int i = 0; i < inventory.Container.Count; i++) {
            var obj = Instantiate(inventory.Container[i].food.prefab, Vector2.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localScale = new Vector2((float)2.5, (float)2.5);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponent<Image>().sprite = inventory.Container[i].food.sprite;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);

            currentLoc = obj.GetComponent<RectTransform>().anchoredPosition;
            obj.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(currentLoc, inventory.Container[i].food).GetComponent<RectTransform>().anchoredPosition;


        }
	}

    public Vector2 GetPosition(int i) { 
        return slots[i].slot.GetComponent<RectTransform>().anchoredPosition;
	}

    public void UpdateDisplay() {
        for (int i = 0; i < inventory.Container.Count; i++) {
            if (itemsDisplayed.ContainsKey(inventory.Container[i])) {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            } else {
                var obj = Instantiate(inventory.Container[i].food.prefab, Vector2.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponent<Image>().sprite = inventory.Container[i].food.sprite;
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);

                currentLoc = obj.GetComponent<RectTransform>().anchoredPosition;
                obj.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(currentLoc).GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }

    /*public FoodSO Cook() {
		slots[40]
        slots[41]
    }*/


}