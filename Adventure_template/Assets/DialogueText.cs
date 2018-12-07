using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour {

    [SerializeField]
    GameObject textPrefab;
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    Vector3 offset;
    public Text MyText { get; set; }
	// Use this for initialization
	void Start () 
    {
        MyText = Instantiate(textPrefab, canvas.transform).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {

        MyText.transform.position = Camera.main.WorldToScreenPoint(transform.position+offset);
	}
}
