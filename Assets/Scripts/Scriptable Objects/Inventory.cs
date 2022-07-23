using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject {
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(FoodSO _food, int _amount) {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++) {
            if (Container[i].food == _food) {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem) {
            Container.Add(new InventorySlot(_food, _amount));
        }
    }
}



[System.Serializable]
public class InventorySlot {
    public FoodSO food;
    public int amount;
    public InventorySlot(FoodSO _food, int _amount) {
		food = _food;
		amount = _amount;
	}
    public void AddAmount(int val) {
        amount += val;
	}
}