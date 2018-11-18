using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AnimatedMovePosition))]
public class InteractionOptionButton : MonoBehaviour {

    Interactable1 interactableParent;
    AnimatedMovePosition myAnim;
    InteractionOption myOption;

    virtual protected void Start()
    {
        interactableParent = GetComponentInParent<Interactable1>();
        myAnim = GetComponent<AnimatedMovePosition>();
    }
    void OnMouseDown()
    {
        Use();
    }
    virtual protected void Use()
    {
        interactableParent.HideOptions();
        Debug.Log("using " + gameObject.name);
        myOption.Interact();
        //inventory.RemoveItem(gameObject); to jeśli chcemy usunąć obiekt z inventory
    }

    public void ShowOption(Vector3 posToMoveTo)
    {
        //StopAllCoroutines();
        //StartCoroutine(MoveTowardsPosition(myPosition,false));   
        if (myAnim == null)
        {
            Debug.Log("ASDGADSG");
        }
        GetComponent<AnimatedMovePosition>().TriggerAnimation(posToMoveTo);
    }
    public void HideOption()
    {
        if (gameObject.activeSelf) myAnim.TriggerAnimation();
    }

    public void SetInteractionOption(InteractionOption option)
    {
        //set sprite
        //set void
        myOption = option;
        GetComponent<SpriteRenderer>().sprite = myOption.Icon;
    }

}
