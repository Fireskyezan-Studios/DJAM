using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class moneyTest : MonoBehaviour {
  public GameObject cam;

  void Start(){

  }

  void Update(){
    if(Input.GetKey("1")){
      cam.GetComponent<playerMoney>().addBalance(5);
    }

    if(Input.GetKey("2")){
      cam.GetComponent<playerMoney>().subtractBalance(5);
    }
  }
}