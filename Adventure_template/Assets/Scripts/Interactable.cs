
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //fields
    bool isFocus = false;


    //properties
    public bool IsFocus { set; get; }


    //methods
    protected virtual void Start()
    {
        if (!GetComponent<Collider2D>())
        {
            Debug.Log("Need to apply trigger collider to interactable gameobject");
        }   
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerController>().Focus=gameObject;
            
        }
        
    }


    void OnTriggerExit2D(Collider2D collider)
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
