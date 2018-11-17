using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable1 : MonoBehaviour
{
    //fields
    [SerializeField]
    List<InteractionOption> options;
    [SerializeField]
    float range = 2f;
    [SerializeField]
    GameObject optionPrefab;

    bool isFocus = false;
    bool isOpen = false;
    SpriteRenderer sprRndr;
    CircleCollider2D col;
    List<GameObject> optionButtons;
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
        optionButtons = new List<GameObject>();
        if (options.Count == 1)
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
            DisplayOptionsTrigger();
        }
    }

    public void DisplayOptionsTrigger()
    {
        if (isOpen)
        {
            HideOptions();
        }
        else
        {
            DisplayOptions();
        }
    }


    public void HideOptions()
    {
        if (isOpen)
        {
            //GetComponentInParent<PlayerController>().canUseInventory = false;
            
            while(optionButtons.Count!=0)
            {
                Destroy(optionButtons[0]);
                optionButtons.RemoveAt(0);
            }
            isOpen = false;
        }
    }
    private void DisplayOptions()
    {
        if (options.Count > 0)
        {
            float angleChange = 360 / options.Count;
            float currAngle = 90;
            foreach (InteractionOption option in options)
            {
                //item.SetActive(true);
                GameObject currOptionButton = Instantiate(optionPrefab, transform);
                //item.GetComponent<ItemInInventory>().MyPosition = 
                currOptionButton.GetComponent<InteractionOptionButton>().ShowOption(Quaternion.Euler(0, 0, currAngle) * Vector2.up * range);
                optionButtons.Add(currOptionButton);
                currAngle += angleChange;
            }
            isOpen = true;
        }
    }

    /*
    public void AddItem(GameObject item)
    {
        if (item.GetComponent<ItemInInventory>())
        {
            GameObject itemPrefab = Instantiate(item, transform);
            itemPrefabs.Add(itemPrefab);
            itemPrefab.SetActive(false);
        }
        else
        {
            Debug.Log("Item dosen't have ItemInInventory component");
            Debug.Break();
        }
    }
    public void RemoveItem(GameObject item)
    {
        itemPrefabs.Remove(item);
        Destroy(item);
    }*/
}
