using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[CreateAssetMenu(fileName ="New Dialogue Interaction Option",menuName = "Interaction Option Dialogue")]
public class InteractionOptionDialogue : InteractionOption
{

    [SerializeField]
    string nodeName;


    public override void Interact()
    {
        TriggerDialogue();
        GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionControllerBehaviour>().PerformingAction = true;//maybe set reference OnEnable
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueRunner>().StartDialogue(nodeName); //maybe set reference OnEnable
    }

}
