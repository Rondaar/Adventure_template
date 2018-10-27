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

    //fields
    [SerializeField]
    float range = 2f;
    List<GameObject> itemPrefabs = new List<GameObject>();
    bool isOpen = false;


    //methods
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
            //GetComponentInParent<PlayerController>().canUseInventory = false;
            foreach (GameObject item in itemPrefabs)
            {
                item.GetComponent<ItemInInventory>().HideItem();
            }
            isOpen = false;
        }
    }
    private void OpenInventory()
    {
        if (itemPrefabs.Count > 0)
        {
            float angleChange = 360 / itemPrefabs.Count;
            float currAngle = 0;
            foreach (GameObject item in itemPrefabs)
            {
                item.SetActive(true);
                item.GetComponent<ItemInInventory>().MyPosition = Quaternion.Euler(0, 0, currAngle) * Vector2.up * range;
                item.GetComponent<ItemInInventory>().ShowItem();
                currAngle += angleChange;
            }
            isOpen = true;
        }
    }

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
    }
}
