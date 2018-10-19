
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //fields
    bool isFocus = false;


    //properties
    public bool IsFocus { set; get; }


    //methods
    protected void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerController>().Focus=gameObject;
            
        }
        
    }
    protected void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && isFocus == true)
        {
            collider.gameObject.GetComponent<PlayerController>().Focus = null;
            isFocus = false;
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting");
    }
}
