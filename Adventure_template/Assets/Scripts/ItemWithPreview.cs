using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemWithPreview : ItemInInventory {
    [SerializeField]
    private Image image;

    protected override void Use()
    {
        base.Use();
        image.enabled = true;
        if(Input.GetMouseButton(1))
        {
            image.enabled = false;
        }
        
    }
}
