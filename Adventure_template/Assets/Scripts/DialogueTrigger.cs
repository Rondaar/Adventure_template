using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class DialogueTrigger : Interactable {

    
    private Text textField;
    public string dialogueName;

    private void Awake()
    {
        textField = GetComponentInChildren<Text>();
    }
    public override void Interact()
    {
        base.Interact();
        TriggerDialogue();
        GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionControllerBehaviour>().PerformingAction =true;
    }
    public void TriggerDialogue()
    {
         
        FindObjectOfType<Yarn.Unity.Example.ExampleDialogueUI>().lineText=textField;
        FindObjectOfType<DialogueRunner>().StartDialogue(dialogueName);
    }
}
