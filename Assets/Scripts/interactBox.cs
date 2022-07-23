/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class interactBox : MonoBehaviour
{

    private TestNPC parentScript;
    [SerializeField] GameObject player;
    private Collider2D playerCol;
    private DialogueRunner dialogueRunner;
    public string conversationStartNode;
    public bool insideBox;
    //if NPC can be talked to, move to parent after testing
    private bool interactable = true;
    //is currently speaking
    private bool isCurrentConversation;
    [SerializeField] GameObject text;



    void Start() {
        //playerCol = player.GetComponent<CapsuleCollider2D>();
        parentScript = GetComponentInParent<TestNPC>();

        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
    }



    void Update() {
        //to run dialogue, must be inside trigger, press e, NPC must be interactable, and there shouldn't already be dialogue running
        //Debug.Log(insideBox + ", " + interactable + ", ");
        if (Input.GetKeyDown("e")) {
            if (insideBox) {
                if (interactable && !dialogueRunner.IsDialogueRunning) {
                    StartConversation();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {

        //Debug.Log("e");

        //if (other == playerCol) {
            //Debug.Log("e2");
        if (parentScript != null) {
            //parentScript.thing(true);
        }
        insideBox = true;
        text.SetActive(true);
        //}
    }

    private void OnTriggerExit2D(Collider2D col) {
        //Debug.Log("a");

        if (parentScript != null) {
            //parentScript.thing(false);
        }
        insideBox = false;
        text.SetActive(false);
        //if (other == player) {
        //TestNPC parentScript = GetComponentInParent<TestNPC>();
        //parentScript.tavern_keeper.inRange();
        //}
    }

    // this file is attached to every character in the scene and so will affect only
    // the targeted character object when functions are called

    // disable scene interaction, activate speaker indicator, and
    // run dialogue from {conversationStartNode}
    private void StartConversation() {
        Debug.Log("Started conversation with NPC.");
        isCurrentConversation = true;
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    // reverse StartConversation's changes: 
    // re-enable scene interaction, deactivate indicator, etc.
    private void EndConversation() {
        if (isCurrentConversation) {
            isCurrentConversation = false;
            Debug.Log("Ended conversation with NPC.");
        }
    }

    // make character not able to be clicked on
    [YarnCommand("disable")]
    public void DisableConversation() {
        interactable = false;
    }

}
*/