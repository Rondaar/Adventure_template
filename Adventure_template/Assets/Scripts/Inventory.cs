using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one inventory detected! Destroying new inventory");
            instance.GetComponentInParent<PlayerController>().waypoints = GetComponentInParent<PlayerController>().waypoints;
            Destroy(gameObject.transform.parent.gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();

    [SerializeField]
    float range = 2f;
    [SerializeField]
    float rotationSpeed = 1;
    
    public List<GameObject> itemPrefabs = new List<GameObject>();
    bool isOpen = false;
    // Use this for initialization
    


    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed);

    }
    public void InventoryTrigger()
    {
        if (isOpen)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }
    public void CloseInventory()
    {
        if (isOpen)
        {
            GetComponentInParent<PlayerController>().canUseInventory = false;
            foreach (GameObject item in itemPrefabs)
            {

                //newItem.transform.position = Vector2.zero;

                item.GetComponent<ItemInInventory>().HideItem();

            }


            isOpen = false;
        }
    }
    private void OpenInventory()
    {
        if (items.Count > 0)
        {
            float angleChange = 360 / items.Count;
            float currAngle = 0;
            foreach (GameObject item in itemPrefabs)
            {
                item.SetActive(true);
                item.GetComponent<ItemInInventory>().myPosition = Quaternion.Euler(0, 0, currAngle) * Vector2.up * range;
                item.GetComponent<ItemInInventory>().ShowItem();
                currAngle += angleChange;

            }
            isOpen = true;
        }

    }

    public void AddItem(Item item)
    {
        items.Add(item);
       
        GameObject itemPrefab = Instantiate(item.prefab, transform);
        itemPrefabs.Add(itemPrefab);
        itemPrefab.GetComponent<ItemInInventory>().myItem = item;
        itemPrefab.SetActive(false);

    }
    public void RemoveItem(GameObject item)
    {
        //need to fix this function
        itemPrefabs.Remove(item);
        items.Remove(item.GetComponent<ItemInInventory>().myItem);
       if (items.Count <2)
        {
            GetComponentInParent<PlayerController>().canUseInventory = true;
        }

        Destroy(item);
       
    }
}
