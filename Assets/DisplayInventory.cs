using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{

    public Inventory inventory;

    public int xStart;
    public int yStart;


    public int xSpacing;

    public int ySpacing;

    public int columns;
    public int rows;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDisplay();
    }

    public void CreateDisplay() {
        for (int i = 0; i < inventory.Container.Count; i++) {
            var obj = Instantiate(inventory.Container[i].food.prefab, Vector2.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponent<Image>().sprite = inventory.Container[i].food.sprite;
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
	}

    public Vector2 GetPosition(int i) {
        return new Vector2(xStart + (xSpacing * (i % columns)), yStart + (-ySpacing * (i/columns)));
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
            }
        }
    }
}
