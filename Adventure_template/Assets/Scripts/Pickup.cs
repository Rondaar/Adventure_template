using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable {

    [SerializeField]
    GameObject myItemForInventory;
    Inventory inventory;

    protected override void Start()
    {
        base.Start();
        inventory = Inventory.instance;    
    }

    public override void Interact()
    {
        PickUpItem();
    }

    public void PickUpItem()
    {
        inventory.AddItem(myItemForInventory);
        Destroy(gameObject);
    }
}
