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


<<<<<<< HEAD
    public int xSpacing;

    public int ySpacing;

    public int columns;
    public int rows;
=======

>>>>>>> 41c420ef9ccc5c6a658b0afbd197b9fcb76af1d9
    private Vector2 currentLoc;

    private TOOL selected;

    Dictionary<InventorySlot, GameObject> itemsDisplayed =
        new Dictionary<InventorySlot, GameObject>();

    public void ChangeText(TOOL tool)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = tool.ToString();
        selected = tool;
    }

    public void FindNearestSlot2(Vector2 loc)
    {
        SlotSO smallest = slots[0];
        float smallestD = 10000;
        for (int i = 0; i < slots.Count; i++)
        {
            if (
                Vector2.Distance(slots[i].slot.GetComponent<RectTransform>().anchoredPosition, loc)
                < smallestD
            )
            {
                if (slots[i].taken)
                {
                    smallest = slots[i];
                    smallestD = Vector2.Distance(
                        slots[i].slot.GetComponent<RectTransform>().anchoredPosition,
                        loc
                    );
                }
            }
        }
        smallest.food = default;
        smallest.taken = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("Drop");
        if (eventData.pointerDrag != null)
        {
            //GameObject.Find("Inventory/Background")
            currentLoc = eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition;
<<<<<<< HEAD
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(
                    currentLoc
                )
                .GetComponent<RectTransform>()
                .anchoredPosition;
=======
            SlotSO slott = FindNearestSlot(currentLoc);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slott.slot.GetComponent<RectTransform>().anchoredPosition;
            slott.food = eventData.pointerDrag.GetComponent<dragAndDrop>().stor.food;
>>>>>>> 41c420ef9ccc5c6a658b0afbd197b9fcb76af1d9
        }
    }

    //NOTE TO SELF: THINK ABOUT EXTRA CRAFTING SLOTS! LIST APPEND??
<<<<<<< HEAD
    public GameObject FindNearestSlot(Vector2 loc)
    {
=======
    public SlotSO FindNearestSlot(Vector2 loc) {
>>>>>>> 41c420ef9ccc5c6a658b0afbd197b9fcb76af1d9
        SlotSO smallest = slots[0];
        float smallestD = 10000;
        for (int i = 0; i < slots.Count; i++)
        {
            if (
                Vector2.Distance(slots[i].slot.GetComponent<RectTransform>().anchoredPosition, loc)
                < smallestD
            )
            {
                if (!slots[i].taken)
                {
                    smallest = slots[i];
                    smallestD = Vector2.Distance(
                        slots[i].slot.GetComponent<RectTransform>().anchoredPosition,
                        loc
                    );
                }
            }
        }
<<<<<<< HEAD
        //smallest.food = sustinence;
        smallest.taken = true;

        return smallest.slot;
=======


        smallest.taken = true;

        /*if (smallest.slot == slots[40]) {
			slots[40].food = 
		} else if (smallest.slot == slots[41]) {

		}*/

        return smallest;

>>>>>>> 41c420ef9ccc5c6a658b0afbd197b9fcb76af1d9
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].taken = false;
        }
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(
                inventory.Container[i].food.prefab,
                Vector2.zero,
                Quaternion.identity,
                transform
            );
            obj.GetComponent<RectTransform>().localScale = new Vector2((float)2.5, (float)2.5);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponent<Image>().sprite = inventory.Container[i].food.sprite;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[
                i
            ].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);

            currentLoc = obj.GetComponent<RectTransform>().anchoredPosition;
<<<<<<< HEAD
            obj.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(
                    currentLoc,
                    inventory.Container[i].food
                )
                .GetComponent<RectTransform>()
                .anchoredPosition;
=======
            obj.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(currentLoc).slot.GetComponent<RectTransform>().anchoredPosition;
            slots[i].food = inventory.Container[i].food;

            obj.GetComponent<dragAndDrop>().stor.food = inventory.Container[i].food;
            obj.GetComponent<dragAndDrop>().stor.amount = inventory.Container[i].amount;

>>>>>>> 41c420ef9ccc5c6a658b0afbd197b9fcb76af1d9
        }
    }

    public Vector2 GetPosition(int i)
    {
        return slots[i].slot.GetComponent<RectTransform>().anchoredPosition;
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]]
                    .GetComponentInChildren<TextMeshProUGUI>()
                    .text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(
                    inventory.Container[i].food.prefab,
                    Vector2.zero,
                    Quaternion.identity,
                    transform
                );
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponent<Image>().sprite = inventory.Container[i].food.sprite;
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[
                    i
                ].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);

                currentLoc = obj.GetComponent<RectTransform>().anchoredPosition;
<<<<<<< HEAD
                obj.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(currentLoc)
                    .GetComponent<RectTransform>()
                    .anchoredPosition;
=======
                obj.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(currentLoc).slot.GetComponent<RectTransform>().anchoredPosition;
                slots[i].food = inventory.Container[i].food;
>>>>>>> 41c420ef9ccc5c6a658b0afbd197b9fcb76af1d9
            }
        }
    }



    /*public FoodSO Cook() {
        slots[40]
        slots[41]
    }*/
}
