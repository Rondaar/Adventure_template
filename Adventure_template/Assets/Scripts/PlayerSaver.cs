using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSaver : Saver
{
    private GameObject gameObjectToSave;     // Reference to the GameObject that will have its activity saved from and loaded to.
    [SerializeField]
    private Vector3 initialPosition;

    private string leftWaypointKey;
    private string rightWaypointKey;

    public Transform[] waypoints;
    //private GameObject inventory;
    //private GameObject gm;
    //private string itemsKey;
    //private string itemPrefabsKey;

    override protected void Awake()
    {
        base.Awake();
        gameObjectToSave = GameObject.FindGameObjectWithTag("Player");
        //make inventory child of player
       // inventory = FindObjectOfType<Inventory>().gameObject;
        //inventory.transform.SetParent(gameObjectToSave.transform);
        //inventory.transform.localPosition = new Vector3(0, 3.3f, 0);
        //gm = GameObject.FindGameObjectWithTag("GM");
        //gm.transform.SetParent(gameObjectToSave.transform);
        //gm.GetComponent<EquipmentManager>().hand = gameObjectToSave.transform.Find("hand");
        if (gameObjectToSave == null)
        {
            Debug.Log("Couldn't find player");
        }
    }
    protected override string SetKey()
    {
        if (gameObjectToSave == null)
        {
            gameObjectToSave = GameObject.FindGameObjectWithTag("Player");
        }
        SetLeftWaypointKey();
        SetRightWaypointKey();
        //SetItemsKey();
       // SetItemPrefabsKey();
        // Here the key will be based on the name of the gameobject, the gameobject's type and a unique identifier.
        return gameObjectToSave.name + gameObjectToSave.GetType().FullName + uniqueIdentifier;
    }
    private void SetLeftWaypointKey()
    {
        leftWaypointKey = gameObjectToSave.name + uniqueIdentifier + "leftWaypoint";
    }

    private void SetRightWaypointKey()
    {
        rightWaypointKey = gameObjectToSave.name + uniqueIdentifier + "rightWaypoint";
    }
    /*
    private void SetItemsKey()
    {
        itemsKey = gameObjectToSave.name + "items";
    }
    private void SetItemPrefabsKey()
    {
        itemPrefabsKey = gameObjectToSave.name + "itemPrefabs";
    }*/

    protected override void Save()
    {
        saveData.Save(key, gameObjectToSave.transform.position);
        saveData.Save(leftWaypointKey,gameObjectToSave.GetComponent<PlayerController>().leftWaypointIndex);
        saveData.Save(rightWaypointKey, gameObjectToSave.GetComponent<PlayerController>().rightWaypointIndex);
        //inventory.transform.parent = null;
        //gm.transform.parent = null;

        //DontDestroyOnLoad(inventory);
        //DontDestroyOnLoad(gm);
        //saveData.Save(itemsKey, gameObjectToSave.GetComponentInChildren<Inventory>().items);
        //saveData.Save(itemPrefabsKey, gameObjectToSave.GetComponentInChildren<Inventory>().itemPrefabs);
    }


    protected override void Load()
    {
        // Create a variable to be passed by reference to the Load function.
        Vector3 myPos = new Vector3();
        int leftIndex=0;
        int rightIndex=1;
        List<Item> items = new List<Item>();
        List<GameObject> itemPrefabs = new List<GameObject>();
        gameObjectToSave.GetComponent<PlayerController>().waypoints = waypoints;
        // If the load function returns true then the activity can be set.
        if (saveData.Load(key, ref myPos))
        {
            gameObjectToSave.transform.position = myPos;
            saveData.Load(leftWaypointKey, ref leftIndex);
            
            saveData.Load(rightWaypointKey, ref rightIndex);
            
            
            /*
            saveData.Load(itemsKey, ref items);
            gameObjectToSave.GetComponentInChildren<Inventory>().items = items;
            saveData.Load(itemPrefabsKey, ref itemPrefabs);
            gameObjectToSave.GetComponentInChildren<Inventory>().itemPrefabs = itemPrefabs;*/
        }
        else
        {
            
             gameObjectToSave.transform.position = initialPosition;
        }
        gameObjectToSave.GetComponent<PlayerController>().rightWaypointIndex = rightIndex;
        gameObjectToSave.GetComponent<PlayerController>().leftWaypointIndex = leftIndex;
        gameObjectToSave.GetComponent<PlayerController>().InitializeWaypoints();
    }
}
