using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable {

    [SerializeField]
    private Item myItem;
    private Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;    
    }
    public override void Interact()
    {
        PickUpItem();
        
    }

    public void PickUpItem()
    {

        inventory.AddItem(myItem);
        // Destroy(gameObject);
        gameObject.SetActive(false);
        
    }
}
