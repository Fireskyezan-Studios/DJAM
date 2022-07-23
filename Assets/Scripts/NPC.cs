using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC
{
    // Dialogue
    private DialogueRunner dialogueRunner;
    private bool isCurrentConversation;

    private int _dialogueLeft;

    private string _conversationStartNode;

    private GameObject eText;

    // Attributes
    private string _name;
    private uint _age;
    private bool _romanceable;
    private int _playerReputation;
    private int _tavernReputation;
    private int _wealth;

    private InMemoryVariableStorage variableStorage;

    public NPC( DialogueRunner dialogueRun, int dialogueRemaining, GameObject eUIText, 
                string iName, uint iAge, bool iRomanceable, int iPlayerReputation, 
                int iTavernReputation, int iWealth) { 
        
        // Dialogue setup
        dialogueRunner = dialogueRun;
        _dialogueLeft = dialogueRemaining;
        eText = eUIText;

        // Attribute setup
        _name = iName;
        _age = iAge;
        _romanceable = iRomanceable;
        _playerReputation = iPlayerReputation;
        _tavernReputation = iTavernReputation;
        _wealth = iWealth;
    }

    // --------Getters & Setters----------

    // Attributes
    public string name {
        get { return _name; }
        set { _name = value; }
    }

    public uint age {
        get { return _age; }
        set { _age = value; }
    }

    public bool romanceable {
        get { return _romanceable; }
        set { _romanceable = value; }
    }

    public int playerReputation {
        get { return _playerReputation; }
        set { _playerReputation = value; }
    }

    public int tavernReputation {
        get { return _tavernReputation; }
        set { _tavernReputation = value; }
    }

    public int wealth {
        get { return _wealth; }
        set { _wealth = value; }
    }

    // Dialogue
    public int DialogueLeft {
        get { return _dialogueLeft; }
        set { _dialogueLeft = value; }
     }

    public string ConversationStartNode {
        get { return _conversationStartNode; }
        set { _conversationStartNode = value; }
	}
          
    // Run in local Start method
    public void begin () {

        variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
        //float testName;
        //variableStorage.TryGetValue("$name", out testName);
        variableStorage.SetValue("$name", _name);

        dialogueRunner.onDialogueComplete.AddListener(() => EndConversation());
    }

    // Run in local Interact method (from IInteractable)
    public void act() {
        if (!dialogueRunner.IsDialogueRunning) {
            Debug.Log("Interact");
            eText.SetActive(false);
            StartConversation();

            if (_dialogueLeft > 0) {
                _dialogueLeft -= 1;
            }
        }
    }

    // Determines whether an NPC can be interacted with. Run in the canInteract method (from IInteractable)
    public bool canAct () {
        if (_dialogueLeft <= 0) {
            return false;
        } else {
            return true;
        }
    }

    // --------Dialogue managers-----------

    // Stolen from yarn docs

    public void StartConversation() {
        Debug.Log("Started conversation with NPC.");
        isCurrentConversation = true;
        dialogueRunner.StartDialogue(_conversationStartNode);
    }

    // reverse StartConversation's changes: 
    // re-enable scene interaction, deactivate indicator, etc.
    public void EndConversation() {
        if (isCurrentConversation) {
            isCurrentConversation = false;
            Debug.Log("Ended conversation with NPC.");
            eText.SetActive(true);
        }
    }

    // make character not able to be clicked on
    [YarnCommand("disable")]
    public void DisableConversation() {
        _dialogueLeft = 0;
    }

}
