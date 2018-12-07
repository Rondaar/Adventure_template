using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButtonsUI : MonoBehaviour 
{
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    Button[] myButtons;
    [SerializeField]
    Vector3[] offsets;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < myButtons.Length; i++)
        {
            myButtons[i].transform.position = Camera.main.WorldToScreenPoint(transform.position + offsets[i]);
        }
    }
}
