using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[CreateAssetMenu(fileName ="New Pickup Interaction Option",menuName = "Interaction Option/Pickup")]
public class InteractionOptionPickup : InteractionOption
{
    [SerializeField]
    GameObject myItemForInventory;


    public override void Interact()
    {
        PickUpItem();
    }

    public void PickUpItem()
    {
        FindObjectOfType<Inventory>().AddItem(myItemForInventory);
        Destroy(MyGO.transform.parent.gameObject);
    }
}
