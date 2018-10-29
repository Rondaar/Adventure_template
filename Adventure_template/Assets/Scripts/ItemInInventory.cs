using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInInventory : MonoBehaviour {
    [SerializeField]
    Vector2 myPosition;
    [SerializeField]
    float speed = 3f;
    Inventory inventory;

    public Vector2 MyPosition { get; set; }

    void Start()
    {
        inventory = GetComponentInParent<Inventory>();
    }
    void OnMouseDown()
    {  
        Use();
    }
    
    void Use()
    {
        inventory.CloseInventory();
        Debug.Log("using " + gameObject.name);
        //inventory.RemoveItem(gameObject); to jeśli chcemy usunąć obiekt z inventory
    }

    IEnumerator MoveTowardsPosition(Vector2 position, bool destroy)
    {  
        while (true)
        {
            if (Vector2.Distance(transform.localPosition, position)>.2f)
            {
               
                transform.localPosition = Vector2.Lerp(transform.localPosition, position, Time.deltaTime*speed);
               
                yield return null;
            }
            else
            {
                //if hiding destroy gameobject
                //TODO: use pooler
                if (destroy)
                {
                    //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().canUseInventory = true;
                    gameObject.SetActive(false);
                }
                yield break;
            }
        }   
    }
    public void ShowItem()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTowardsPosition(myPosition,false));   
    }
    public void HideItem()
    {
        StopAllCoroutines();
        if (gameObject.activeSelf) StartCoroutine(MoveTowardsPosition(Vector2.zero,true));
    }
}
