using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable1 : MonoBehaviour
{
    //fields
    [SerializeField]
    List<InteractionOption> options;

    bool isFocus = false;
    SpriteRenderer sprRndr;
    CircleCollider2D col;
    //properties
    public bool IsFocus { set; get; }

    
    //methods
    void Start()
    {
        if (!GetComponent<Collider2D>())
        {
            Debug.Log("Need to apply trigger collider to interactable gameobject");
        }
        sprRndr.color = new Color(sprRndr.color.r, sprRndr.color.g, sprRndr.color.b, 0);
        if (options.Count==1)
        {
            sprRndr.sprite = options[0].Icon;
        }
    }
    void Awake()
    {
        sprRndr = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<InteractionControllerBehaviour>().Focus=gameObject;
        }
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<InteractionControllerBehaviour>().Focus = gameObject;
            float alpha = Mathf.Clamp01(1-Mathf.Abs(transform.position.x - collider.transform.position.x)/col.radius);
            sprRndr.color = new Color(sprRndr.color.r, sprRndr.color.g, sprRndr.color.b, alpha);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" )//&& isFocus == true)
        {
            collider.gameObject.GetComponent<InteractionControllerBehaviour>().Focus = null;
            isFocus = false;
            Debug.Log("fasle");
            sprRndr.color = new Color(sprRndr.color.r, sprRndr.color.g, sprRndr.color.b, 0);
        }
    }


    public void Interact()
    {
        Debug.Log("Interacting");
        if (options.Count == 1)
        {
            options[0].Interact();
        }
        else
        {
            DisplayOptions();
        }
    }

    private void DisplayOptions()
    {

    }
}
