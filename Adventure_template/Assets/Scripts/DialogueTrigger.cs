﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class DialogueTrigger : Interactable {

    [SerializeField]
    private Text textField;
    public string dialogueName;
    public override void Interact()
    {
        base.Interact();
        TriggerDialogue();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().SetPerformingAction(true);
    }
    public void TriggerDialogue()
    {
         
        FindObjectOfType<Yarn.Unity.Example.ExampleDialogueUI>().lineText=textField;
        FindObjectOfType<DialogueRunner>().StartDialogue(dialogueName);
    }
}