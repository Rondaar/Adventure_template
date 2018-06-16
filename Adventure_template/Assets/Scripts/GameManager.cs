using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity.Example;


public class GameManager : MonoBehaviour {

    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Game Manager detected! Destroying new Game Manager");
            instance.GetComponent<ExampleDialogueUI>().lineText = GetComponent<ExampleDialogueUI>().lineText;
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    [HideInInspector]
    public int leftWaypointIndex=0;
    [HideInInspector]
    public int rightWaypointIndex=1;
    [HideInInspector]
    public int initialWaypointIndex=0;
   
    
}
