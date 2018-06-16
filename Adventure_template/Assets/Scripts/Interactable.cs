
using UnityEngine;

public class Interactable : MonoBehaviour {
    [HideInInspector]
    public bool isFocus = false;

    protected void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerController>().SetFocus(gameObject);
            
        }
        
    }
    protected void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && isFocus == true)
        {
            collider.gameObject.GetComponent<PlayerController>().SetFocus(null);
            isFocus = false;
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting");
    }
}
