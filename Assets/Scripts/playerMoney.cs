using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class playerMoney : MonoBehaviour
{
  public int balance;
  public TextMeshProUGUI moneyText;
  // Initialize
  void Start()
  {
    balance = 100;
    moneyText.text = "Cash: " + balance.ToString();
  }
  // Update called once per frame
  void Update()
  {
    //moneyText = GetComponent<TextMeshProUGUI>();
    //moneyText.text = "Cash: " + balance.ToString();
  }

  public void addBalance(int revenue)
  {
    balance += revenue;
    moneyText.text = "Cash: " + balance.ToString();
    Debug.Log("Added " + revenue + "dollars");
  }

  public void subtractBalance(int expenditure)
  {
    if(balance - expenditure < 0)
    {
      Debug.Log("ERROR: Insufficient Balance.");
      return;
    }

    balance -= expenditure;
    moneyText.text = "Cash: " + balance.ToString();
    Debug.Log("Subtracted " + expenditure + "dollars");
  }
}