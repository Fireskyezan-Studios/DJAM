using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Test_NPC : MonoBehaviour, IInteractable {

    public NPC npc;
    
    [SerializeField] private int dialogueLeft;

    [SerializeField] private string conversationStartNode;

    [SerializeField] private GameObject eText;

    private DialogueRunner dialogueRunner;

    public NPCSO ScriptNPC;


    public bool canInteract() {
        return npc.canAct();
    }

	public void Interact() {
        npc.act();

        dialogueLeft = npc.DialogueLeft;
    }

    void Start() {
        name = ScriptNPC.npcName;
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        npc = new NPC(dialogueRunner, dialogueLeft, eText, name, ScriptNPC.age,
            ScriptNPC.romanceable, ScriptNPC.playerReputation, ScriptNPC.tavernReputation, 
            ScriptNPC.wealth);
        npc.ConversationStartNode = conversationStartNode;
        npc.begin();
    }
}
