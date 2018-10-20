using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/ActionItem")]
public class ActionItem : Equipment {
    
    public override void Use()
    {
        base.Use();
       // EquipmentManager.instance.Equip(this);
    }
}
