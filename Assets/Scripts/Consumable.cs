using UnityEngine;

public abstract class Consumable: MonoBehaviour
{
  protected abstract void DoCook(Consumable c1, Consumable c2);
  protected string _name;

  public void Cook(Consumable c1, Consumable c2)
  {
    DoCook(c1, c2);
    Debug.Log("You combined " + c1.name + " and " + c2.name);
  }

  public string setName 
  {
    set {_name = value;}
  }
}