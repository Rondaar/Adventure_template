using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment",menuName ="Inventory/Equipment")]
public class Equipment : Item {
    public EquipmentSlot equipmentSlot;
    public bool isActionItem=false;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);

    }
    virtual public void Action()
    {
        Debug.Log("Performing Action");
    }
    
}
public enum EquipmentSlot { Head, Chest, Legs, Weapon, Feet }
