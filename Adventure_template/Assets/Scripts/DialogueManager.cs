using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;
    private TextMesh textMesh;

    
	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}
	
	public void StartDialogue(Dialogue dialogue, TextMesh textMesh)
    {
        EndDialogue();
        sentences.Clear();
        this.textMesh = textMesh; 
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            StopAllCoroutines();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private void EndDialogue()
    {
        if (textMesh != null) {
            //textMesh.GetComponentInParent<DialogueTrigger>().dialogueStarted = false; new way
            textMesh.text = "";
        }

    }
    private IEnumerator TypeSentence(string sentence)
    {
        WaitForSeconds wait = new WaitForSeconds(.1f);
        textMesh.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textMesh.text += letter;
            yield return wait;
        }
    }
}
