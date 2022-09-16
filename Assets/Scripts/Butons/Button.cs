using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button
{
    //for inventory
    public GameObject player;

    private FoodSO food;

    public Button (FoodSO _fud, GameObject _player) {
        food = _fud;
        player = _player;
    }

    void Click() {
        player.GetComponent<pInventory>().addInv(food);
    }
}
