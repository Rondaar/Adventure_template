using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using Yarn.Unity.Example;

public class ItemWithDialogue : ItemInInventory {
    [SerializeField]
    private string dialogueName;
    private Text textField;
    ExampleDialogueUI exampleUI;
    DialogueRunner dialogueRunner;
    InteractionControllerBehaviour playerInteractionalController;

    protected override void Start()
    {
        base.Start();
        textField = GetComponentInChildren<Text>();
        exampleUI = FindObjectOfType<Yarn.Unity.Example.ExampleDialogueUI>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        playerInteractionalController = FindObjectOfType<InteractionControllerBehaviour>();
    }

    protected override void Use()
    {
        base.Use();
        playerInteractionalController.PerformingAction = true;
        TriggerDialogue();

        
    }

    public void TriggerDialogue()
    {
        exampleUI.lineText = textField;
        dialogueRunner.StartDialogue(dialogueName);
    }
}
