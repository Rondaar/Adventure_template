using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatedMovePosition))]
public class ItemInInventory : MonoBehaviour {
 
    Inventory inventory;
    AnimatedMovePosition myAnim;

    virtual protected void Start()
    {
        inventory = GetComponentInParent<Inventory>();
        myAnim = GetComponent<AnimatedMovePosition>();
    }
    void OnMouseDown()
    {  
        Use();
    }
    virtual protected void Use()
    {
        inventory.CloseInventory();
        Debug.Log("using " + gameObject.name);
        //inventory.RemoveItem(gameObject); to jeśli chcemy usunąć obiekt z inventory
    }
   
    public void ShowItem(Vector3 posToMoveTo)
    {
        //StopAllCoroutines();
        //StartCoroutine(MoveTowardsPosition(myPosition,false));   
        if (myAnim == null)
        {
            Debug.Log("ASDGADSG");
        }
        GetComponent<AnimatedMovePosition>().TriggerAnimation(posToMoveTo);
    }
    public void HideItem()
    {
        if (gameObject.activeSelf) myAnim.TriggerAnimation();
    }
}
