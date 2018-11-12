using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputBehaviour))]
public class InteractionControllerBehaviour : MonoBehaviour {

    GameObject focus;
    Inventory inventory;
    InputBehaviour input;
    bool performingAction = false;
   
    public GameObject Focus
    {
        get
        {
            return focus;
        }
        set
        {
            if (focus == null)
            {
                focus = value;
                value.GetComponent<Interactable1>().IsFocus = true;
            }
            else if (value == null)
            {
                focus = null;
            }
        }
    }

    public bool PerformingAction
    {
        get
        {
            return performingAction;
        }
        set
        {
            performingAction = value;
        }
    }

    private void Start()
    {
        inventory = GetComponentInChildren<Inventory>();
        input = GetComponent<InputBehaviour>();
    }

    private void Update()
    {
        if (!performingAction)
        {
            if ( input.ActionA && focus != null)
            {
                focus.GetComponent<Interactable1>().Interact();
                inventory.CloseInventory();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                inventory.InventoryTrigger();
            }
        }
    }
}
