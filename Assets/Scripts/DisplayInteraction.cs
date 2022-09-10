using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System.Xml;
using static UnityEngine.EventSystems.EventTrigger;
using Newtonsoft.Json.Linq;

public class DisplayInteraction : MonoBehaviour, IDropHandler
{
    public List<SlotSO> slots;

    public Inventory inventory;


    public List<RecipieSO> recipies;

    public SlotSO oSlot;

    public FoodSO dubFood;

    public int columns;
    public int rows;
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

            SlotSO slott = FindNearestSlot(currentLoc);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = slott.slot.GetComponent<RectTransform>().anchoredPosition;

            slott.food = eventData.pointerDrag.GetComponent<dragAndDrop>().stor.food;
        }
    }

    //NOTE TO SELF: THINK ABOUT EXTRA CRAFTING SLOTS! LIST APPEND??
    public SlotSO FindNearestSlot(Vector2 loc)
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

        smallest.taken = true;

        return smallest;
    }

    public void slotUpdate (InventorySlot s) {

        for (int i = 0; slots.Count > i; i++) {
			if (slots[i].food == s.food) {
				slots[i].taken = false;
				slots[i].food = default;
			}
		}

	}

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].taken = false;
            slots[i].food = default;

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
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
			obj.name = inventory.Container[i].food.name;
			itemsDisplayed.Add(inventory.Container[i], obj);

            currentLoc = obj.GetComponent<RectTransform>().anchoredPosition;
            obj.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(currentLoc).slot.GetComponent<RectTransform>().anchoredPosition;

            obj.GetComponent<dragAndDrop>().stor.food = inventory.Container[i].food;
            obj.GetComponent<dragAndDrop>().stor.amount = inventory.Container[i].amount;
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

            

            
            if (inventory.Container.Count < itemsDisplayed.Count) {

				bool exists = false;

				InventorySlot slotte = null;

				foreach (KeyValuePair<InventorySlot, GameObject> entry in itemsDisplayed) {
					exists = false;
					slotte = entry.Key;

					for (int j = 0; j < inventory.Container.Count; j++) {
						
						if (entry.Key == inventory.Container[j]) {
							exists = true;
						}
					}

    				if (exists == false && slotte != null) {
						slotUpdate(slotte);
						itemsDisplayed.Remove(slotte);
                        Destroy(GameObject.Find(slotte.food.name));
						
						break;
					}

				}


				
			}
			


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
                obj.name = inventory.Container[i].food.name;
                itemsDisplayed.Add(inventory.Container[i], obj);

                currentLoc = obj.GetComponent<RectTransform>().anchoredPosition;
                obj.GetComponent<RectTransform>().anchoredPosition = FindNearestSlot(currentLoc).slot
                    .GetComponent<RectTransform>()
                    .anchoredPosition;

                obj.GetComponent<dragAndDrop>().stor.food = inventory.Container[i].food;
                obj.GetComponent<dragAndDrop>().stor.amount = inventory.Container[i].amount;
            }
        }
    }


    public void cook() {
        
        

        SlotSO ing1 = slots[40];
        SlotSO ing2 = slots[41];

        Debug.Log(ing1.food);
		Debug.Log(ing2.food);


		List<SlotSO> sList = new List<SlotSO> { };
        List<FoodSO> fList = new List<FoodSO> { };

        List<RecipieSO> rList = new List<RecipieSO> { };

        if (ing1.food != null) {
            sList.Add(ing1);
        }

        if (ing2.food != null) {
            sList.Add(ing2);
        }

        if (sList.Count > 0) {

            bool canCraft = true;
            bool recipieFound = false;

            //we need to check if the recipie is valid and you have enough materials in your inventory

            //Add all given recipies to rList
			for (int i = 0; i < recipies.Count; i++) {
				rList.Add(recipies[i]);
			}

            
            //Iterates over inventory, and ingredients then subtracts 1 from each ingredient.
			for (int i = 0; i < inventory.Container.Count; i++) {
                for (int j = 0; j < sList.Count; j++) {
                    if (inventory.Container[i].food == sList[j].food) {
                        if (inventory.Container[i].amount <= 0) {
				            canCraft = false;
				            
			            } else {
                            
				            //inventory.Container[i].amount -= 1;
			            }

		            }
                }
			}

			//iterates over ingredients then adds food values to flist
			for (int i = 0; i < sList.Count; i++) {
				fList.Add(sList[i].food);
			}

			var hList = new HashSet<FoodSO>(fList);

			// If there's only 1 ingredient, check all recipies and add product to inventory
			if (sList.Count == 1) {
				for (int i = 0; i < recipies.Count; i++) {
					if (sList[0].food == recipies[i].ingredients[0] && recipies[i].tool == selected ) {
                        //selected
                        //inventory.AddItem(recipies[i].product, 1);
                        recipieFound = true;
                        break;
					}
				}
			}
			// If there's more than 1 ingredient, check all recipies and add product to inventory
			else {
				for (int i = 0; i < rList.Count; i++) {
					var hRecipies = new HashSet<FoodSO>(rList[i].ingredients);

					if (hList.SetEquals(hRecipies) && selected == rList[i].tool) {
						//inventory.AddItem(recipies[i].product, 1);
                        recipieFound=true;
						break;
					}
				}

			}

            if (!recipieFound) {
                //canCraft = false;
            }

			if (!canCraft) {
                return;
            }

			//Iterates over inventory, and ingredients then subtracts 1 from each ingredient.
			for (int i = 0; i < inventory.Container.Count; i++) {
				for (int j = 0; j < sList.Count; j++) {
					if (inventory.Container[i].food == sList[j].food) {

                        inventory.Container[i].RemoveAmount(1);

                        if (inventory.Container[i].amount <= 0) {
                            inventory.RemoveItem(inventory.Container[i].food);
                        }

						

					}
				}
			}



			// If there's only 1 ingredient, check all recipies and add product to inventory
			if (sList.Count == 1) {
                Debug.Log("Got here");
                bool hasRecipie = false;
                for (int i = 0; i < recipies.Count; i++) {
                    if (sList[0].food == recipies[i].ingredients[0] && recipies[i].tool == selected) {
                        //selected
                        inventory.AddItem(recipies[i].product, 1);
                        hasRecipie = true;
                        break;

                    }
                }

                if (!hasRecipie) {
					inventory.AddItem(dubFood, 1);
				}
            }
			// If there's more than 1 ingredient, check all recipies and add product to inventory
			else {
                bool hasRecipie = false;
                for (int i = 0; i < rList.Count; i++) {
                    var hRecipies = new HashSet<FoodSO>(rList[i].ingredients);

                    if (hList.SetEquals(hRecipies) && selected == rList[i].tool) {
                        inventory.AddItem(recipies[i].product, 1);
                        hasRecipie = true;
                        break;
					}
				}

                if (!hasRecipie) {
					inventory.AddItem(dubFood, 1);
				}
                
            }
           


            /*
            for (int i = 0; i < sList.Count; i++) {
                fList.Add(sList[i].food);
            }

            for (int i = 0; i < recipies.Count; i++) {
                rList.Add(recipies[i].ingredients.food);
            }

            var hList = new HashSet<FoodSO>(fList);
            var hRecipies = new HashSet<RecipieSO>(recipies);

            if (hList.SetEquals(list2);)*/

                     

        }
    }
     

    /*public FoodSO Cook() {
		slots[40] 

        slots[41]
    }*/
}
