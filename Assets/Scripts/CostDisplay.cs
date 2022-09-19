using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class CostDisplay : MonoBehaviour
{

    public FoodSO food;

    private TextMeshProUGUI text;

	// Start is called before the first frame update
	void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = food.name + ": $" + food.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
