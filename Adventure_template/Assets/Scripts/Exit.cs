using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Exit : Interactable {
    [SerializeField]
    private bool isInteractable=true;
   // [Header("New Scene")]
    [SerializeField]
    private string sceneToGo;
   // [SerializeField][Tooltip("Set to true if you want to enter a room which is on the right, if the room will be on the left set to false")]
    //private bool enterRoomOnRight;
   // [SerializeField][Tooltip("Enter initial index only when you want to enter room on the left")]
   // private int initialWaypointIndex=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isInteractable && collision.gameObject.tag == "Player")
        {
            
            ChangeScene(sceneToGo);
        }
    }
    public override void Interact()
    {
        if (isInteractable)
        {
            ChangeScene(sceneToGo);
        }
    }

    private void ChangeScene(string scene)
    {
        /*
        if (enterRoomOnRight == true)
        {
            GameManager.instance.leftWaypointIndex = 1;
            GameManager.instance.rightWaypointIndex = 2;
            GameManager.instance.initialWaypointIndex = 1;
        }
        else
        {
            GameManager.instance.leftWaypointIndex = initialWaypointIndex-1;
            GameManager.instance.rightWaypointIndex = initialWaypointIndex;
            GameManager.instance.initialWaypointIndex = initialWaypointIndex;
        }
        */

        FindObjectOfType<SceneController>().FadeAndLoadScene(scene);
    }
}
