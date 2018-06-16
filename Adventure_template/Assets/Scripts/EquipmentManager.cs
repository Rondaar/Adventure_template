using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else { instance = this; }
    }
    #endregion
    
    #region OnSceneLoaded
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
       // int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        //vStorage = GetComponent<ExampleVariableStorage>();
        //currentEquipment = new Equipment[numSlots];
        //inventory = GetComponentInChildren<Inventory>();
        //Debug.Log(numSlots);

    }
    #endregion
    private Equipment[] currentEquipment;
    private Inventory inventory;
    
    public Transform hand;
    
    private ExampleVariableStorage vStorage;
    
    private void Start()
     {
         int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
         vStorage = GetComponent<ExampleVariableStorage>();
         currentEquipment = new Equipment[numSlots];
        
        // inventory = Inventory.instance;
     }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;
        if (newItem.isActionItem)
        {
           
            Inventory.instance.GetComponentInParent<PlayerController>().actionItem = newItem;
            //remove current action item. Only one action item allowed
            if (currentEquipment == null) Debug.Break();
            foreach(Equipment equipment in currentEquipment)
            {
                if (equipment!=null && equipment.isActionItem)
                {
                    Remove((int)equipment.equipmentSlot);
                    //currentEquipment[slotIndex] = newItem;
                    
                }
            }

        }

        Debug.Log(slotIndex);
        Debug.Log(currentEquipment.Length);
        if (currentEquipment[slotIndex] != null)
        {
            Remove(slotIndex);
            
        }
        currentEquipment[slotIndex] = newItem;
        if (newItem.equipmentSlot== EquipmentSlot.Weapon)
        {
            GameObject itemInHand = Instantiate(newItem.prefab, hand);
            //set action item variable to true

            vStorage.SetValue("$actionItem", new Yarn.Value(true) );
        }
    }
    private void Update()
    {
        //  Debug.Log(currentEquipment.Length);
        if (currentEquipment.Length == 0) Debug.Break();
    }
    public void Remove(int slotIndex)
    {
        
        Equipment oldItem = currentEquipment[slotIndex];
        currentEquipment[slotIndex] = null;
        Inventory.instance.AddItem(oldItem);
        if (oldItem.isActionItem)
        {
            vStorage.SetValue("$actionItem", new Yarn.Value(false));
            Destroy(hand.GetChild(0).gameObject);
        }
    }
    [Yarn.Unity.YarnCommand("removeItemYarn")]
    public void RemoveYarn(string slotIndex)
    {
        Debug.Log("RE MO VING");
        
        Equipment oldItem = currentEquipment[int.Parse(slotIndex)];
        currentEquipment[int.Parse(slotIndex)] = null;
        Inventory.instance.AddItem(oldItem);
        if (oldItem.isActionItem)
        {
            vStorage.SetValue("$actionItem", new Yarn.Value(false));
            Destroy(hand.GetChild(0).gameObject);
        }
    }
}
