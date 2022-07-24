using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slot", menuName = "Slot")]
public class SlotSO : ScriptableObject {
    public GameObject slot;
    public bool taken;
}