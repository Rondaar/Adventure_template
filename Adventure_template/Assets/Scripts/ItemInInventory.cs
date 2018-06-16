using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInInventory : MonoBehaviour {
    public Vector2 myPosition;
    
    public float speed = 3f;

    private Quaternion initialRotation;

    public Item myItem;

    private Inventory inventory;
    private void Start()
    {
        initialRotation = transform.localRotation;
        inventory = GetComponentInParent<Inventory>();
    }
    private void OnMouseDown()
    {
        //Equip
        inventory.CloseInventory();
        myItem.Use();
        
        inventory.RemoveItem(gameObject);
        //Inventory.instance.GetComponentInParent<PlayerController>().SetCurrentItem()
    }
    private void LateUpdate()
    {
        //remain stable rotation
        transform.rotation = initialRotation;
    }
    
    private IEnumerator MoveTowardsPosition(Vector2 position, bool destroy)
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
                    
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().canUseInventory = true;
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
