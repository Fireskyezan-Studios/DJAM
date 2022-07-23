using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New NPC", menuName ="NPC")]
public class NPCSO : ScriptableObject
{
    public string npcName;
    public uint age;
    public bool romanceable;
    public int playerReputation;
    public int tavernReputation;
    public int wealth;
}
